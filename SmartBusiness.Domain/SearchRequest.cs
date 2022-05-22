//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Text;

//namespace SmartBusiness.Domain
//{
//    public class SearchRequest
//    {
//        public int Draw { get; set; }

//        /// <summary>
//        /// Indicador de primeiro registro de paginação. Este é o ponto de partida no conjunto de dados atual (com base no índice 0 - ou seja, 0 é o primeiro registro).
//        /// </summary>
//        public int Start { get; set; }

//        /// <summary>
//        /// Número de registros que a tabela pode exibir no sorteio atual. Espera-se que o número de registros retornados seja igual a esse número, a menos que o servidor tenha menos registros para retornar. Observe que isso pode ser -1 para indicar que todos os registros devem ser retornados (embora isso negue quaisquer benefícios do processamento no servidor!)
//        /// </summary>
//        public int Length { get; set; }

//        public SearchInfo Search { get; set; }
//        public List<SortInfo> Order { get; set; }
//        public List<ColumnInfo> Columns { get; set; }
//        public string Error { get; set; } = "";
//        public IList Filter { get; set; }
//    }

//    public class SearchInfo
//    {
//        /// <summary>
//        /// Valor de pesquisa global. Para ser aplicado a todas as colunas que possuem searchablecomo true.
//        /// </summary>
//        public string Value { get; set; }

//        /// <summary>
//        /// 	truese o filtro global deve ser tratado como uma expressão regular para pesquisa avançada, falsecaso contrário. Observe que normalmente os scripts de processamento do lado do servidor não executam expressões regulares procurando motivos de desempenho em grandes conjuntos de dados, mas é tecnicamente possível e a critério do seu script.
//        /// </summary>
//        public bool Regex { get; set; }
//    }

//    public class SortInfo
//    {
//        /// <summary>
//        /// Coluna à qual a ordem deve ser aplicada. Esta é uma referência de índice para a columnsmatriz de informações que também é enviada ao servidor.
//        /// </summary>
//        public string Column { get; set; }

//        /// <summary>
//        /// Direção de pedidos para esta coluna. Será ascou descpara indicar a ordem crescente ou decrescente, respectivamente.
//        /// </summary>
//        public bool Descending { get; set; }
//    }

//    public class ColumnInfo
//    {
//        public string Data { get; set; }
//        public string Name { get; set; }

//        /// <summary>
//        /// Sinalizador para indicar se esta coluna é pesquisável ( true) ou não ( false).
//        /// </summary>
//        public bool Searchable { get; set; }
//        public bool Orderable { get; set; }
//        public SearchInfo Search { get; set; }
//    }

//}
