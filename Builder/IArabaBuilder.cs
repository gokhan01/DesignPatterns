namespace Builder
{
    //Builder
    abstract class IArabaBuilder
    {
        protected Araba araba;
        public Araba Araba => araba;

        public abstract void SetMarka();
        public abstract void SetModel();
        public abstract void SetKM();
        public abstract void SetVites();
    }
}
