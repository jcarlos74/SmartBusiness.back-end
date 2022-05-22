using System;
using System.Collections.Generic;
using System.Text;

namespace SmartBusiness.Infra.DataGrid.PrimeNG.Table.Models
{
    public class FilterModel
    {
        /// <summary>
        /// Filtra o objeto com campo como chave e valor de filtro, filtra matchMode como valor
        /// </summary>
        public Dictionary<string, object> Filters { get; set; }

        /// <summary>
        /// Valor do filtro global se disponível
        /// </summary>
        public string globalFilter { get; set; }

        /// <summary>
        /// Primeira linha
        /// </summary>
        public int First { get; set; }

        /// <summary>
        /// Número de linhas por página
        /// </summary>
        public int Rows { get; set; }

        /// <summary>
        /// Nome do campo para ordenar no modo de ordenação simples
        /// </summary>
        public string SortField { get; set; }

        /// <summary>
        /// Ordem de ordenação como número, 1 para asc e -1 para dec no modo de ordenação simples
        /// </summary>
        public int SortOrder { get; set; }

        /// <summary>
        /// Uma matriz de objetos SortMeta usados na classificação de várias colunas. Cada SortMeta possui propriedades de campo e ordem.
        /// </summary>
        public List<FilterSortMeta> MultiSortMeta { get; set; }
    }
}
