﻿namespace BusinessLayer.Abstract
{
    public interface IGenericSevice<T> where T : class
    {
        void TAdd(T entity);
        void TDelete(T entity);
        void TUpdate(T entity);
        T TGetByID(int id);
        List<T> TGetListAll();
    }
}
