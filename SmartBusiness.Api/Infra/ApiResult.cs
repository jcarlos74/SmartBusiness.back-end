﻿namespace SmartBusiness.Infra
{
    public class ApiResult<T>
    {
        /// <summary>
        /// Se True indica que a operação foi bem sucedida
        /// </summary>
        public bool Success { get; set; }

        public T Data { get; set; }

        public string Message { get; set; }

        /// <summary>
        /// Quantidade de linhas retornadas
        /// </summary>
        public int TotalRows { get; set; }
    }
}
