namespace ExcelGenAPI
{
    
    
        public class DataItem
        {
        internal object? temperatura;
        internal object? umidade;
        internal object? AF;

        public float S { get; set; }
            public float Ac { get; set; } //scc não tem dados de corrente
            public float C { get; set; }
            public float Av { get; set; }
            public float V { get; set; }
            public float F { get; set; }
            public float Af { get; set; } // no scc tem calibração de frequencia


        }

        public class MyDataModel
        {
        internal object? DadosAV;
        internal object? dt;

        public string? S { get; set; }
            public string? D { get; set; }
            public string? E { get; set; }

            public float Ac { get; set; }
            public float C { get; set; }
            public float Av { get; set; }
            public float V { get; set; }
            public float F { get; set; }
        public float Af { get; set; }
            public List<DataItem>? Dt { get; set; }
            public string? EquipmentType { get; internal set; }
    }
    


}
