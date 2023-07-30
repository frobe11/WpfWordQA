namespace WpfWordQA
{
    public class QA : IQA
    {
        private string _Q;
        private string _A;

        public QA()
        {
            
        }
        public QA(string q, string a)
        {
            _Q = q;
            _A = a;
        }
        

        public string Q
        {
            get => _Q;
            set => _Q = value;
        }

        public string A
        {
            get => _A;
            set => _A = value;
        }
    }
}