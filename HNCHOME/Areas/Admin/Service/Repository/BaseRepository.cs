﻿using HNCHOME.Attr;
using HNCHOME.Service.Interface;
using System.Reflection;

namespace HNCHOME.Service.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected HNCDbContext _context = null;
        private DbSet<T> table = null;
        public BaseRepository(HNCDbContext context)
        {
            this._context = context;
            table = _context.Set<T>();
        }
        public int Delete(object id)
        {
            T existing = GetById(id);
            var result = table.Remove(existing);
            if (result != null)
            {
                Save();
                return (int)StatusCodeRespon.Success;
            }
            return (int)StatusCodeRespon.BadRequest;

        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public virtual int Insert(T obj)
        {

            // validate chung - base xử lý
            var isValid = ValidateObject(obj);
            // Validate đặc thù từng đối tượng
            if (isValid == true)
            {
                isValid = ValidateObjectCustom(obj);
            }
            if (isValid == true)
            {
                var result = table.Add(obj);
                if (result != null)
                {
                    Save();
                    return (int)StatusCodeRespon.UpdateSuccess;
                }
            }
            return (int)StatusCodeRespon.BadRequest;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public virtual int Update(T obj)
        {
            var result = table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            if (result != null)
            {
                Save();
                return (int)StatusCodeRespon.UpdateSuccess;
            }
            return (int)StatusCodeRespon.BadRequest;
        }
        bool ValidateObject(T entity)
        {
            // List chứa lỗi
            var count = 0;
            // Các thông tin bắt buộc nhập
            //1. Kiểm tra tất cả các properties của đối tượng
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(entity);
                var propertyNameOriginal = property.Name;
                
                var propertyNames = property.GetCustomAttributes(typeof(PropertyName), true);
               
                var propertyNotEmptys = property.GetCustomAttributes(typeof(NotEmpty), true);
                
                var propertyMaxLength = property.GetCustomAttributes(typeof(MaxLength), true);
                
                var propertyDuplicate = property.GetCustomAttributes(typeof(CheckDuplicate), true);
                
                var propertyCheckDate = property.GetCustomAttributes(typeof(checkDate), true);

                // Xem các property đó có có tồn tại PropertyName không
                if (propertyNames.Length > 0)
                {
                    // Thay đổi giá trị cũ của entity gán bằng PropertyName được đặt
                    propertyNameOriginal = ((PropertyName)propertyNames[0]).Name;
                }
                // Xem các property đó có phải là property có phải thuộc tính bắt buộc nhập
                if (propertyNotEmptys.Length > 0)
                {
                    //3. nếu thông tin bắt buộc nhập hiển thị cảnh báo hoặc đánh giấu trang thái không hợp lệ
                    if (propertyValue == null || string.IsNullOrEmpty(propertyValue.ToString()))
                    {
                        count += 1;
                    }
                        
                }
                if (propertyMaxLength.Length > 0)
                {
                    var length = ((MaxLength)propertyMaxLength[0]).Length;
                    //3. nếu thông tin bắt buộc nhập hiển thị cảnh báo hoặc đánh giấu trang thái không hợp lệ
                    if (propertyValue != null && ((string)propertyValue).Trim().Length > length)
                    {
                        count += 1;
                    }
                }
                if (propertyDuplicate.Length > 0)
                {
                    if (propertyValue != null)
                    {
                        
                    }
                }
                if (propertyCheckDate.Length > 0)
                {
                    if (propertyValue != null)
                    {
                        if ((DateTime)propertyValue > DateTime.Now)
                        {
                            count += 1;
                        }
                    }
                }

            }
            if (count > 0)
            {
                return false;
            }
            return true;
        }
        protected virtual bool ValidateObjectCustom(T entity)
        {
            return true;
        }

    }
}
