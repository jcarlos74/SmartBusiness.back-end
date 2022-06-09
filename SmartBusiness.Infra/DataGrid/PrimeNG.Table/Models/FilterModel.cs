using System;
using System.Collections.Generic;
using System.Text;

namespace SmartBusiness.Infra.DataGrid.PrimeNG.Table.Models
{
    public class FilterModel
    {
        /// <summary>
        /// Filtra uma coluna conforme o valor passado em FilterColumn.Value
        /// </summary>
        public List<FilterColumn> FiltersColumns { get; set; }

        /// <summary>
        /// Valor do filtro global se disponível
        /// </summary>
        public string globalFilter { get; set; }

        /// <summary>
        /// Indice da linha por onde deve começar a contagem da paginação
        /// </summary>
        public int FirstRowIndex { get; set; }

        /// <summary>
        /// Número de linhas por página
        /// </summary>
        public int RowsPerPage { get; set; }

        /// <summary>
        /// Página Atual
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Nome do campo para ordenar no modo de ordenação simples
        /// </summary>
        public string SortField { get; set; }

        /// <summary>
        /// Ordem de ordenação como número, 1 para asc e -1 para dec no modo de ordenação simples
        /// </summary>
        public int SortOrder { get; set; }

        /// <summary>
        /// Uma matriz de objetos FilterSorter usados na classificação de várias colunas. Cada Sorter possui propriedades de campo e ordem.
        /// </summary>
        public List<FilterSorter> MultiSort { get; set; }
    }

    public class FilterColumn
    {
        public string ColumnName { get; set; } 
        public object Value { get; set; }
        public string FilterMatchMode { get; set; }
    }
}
