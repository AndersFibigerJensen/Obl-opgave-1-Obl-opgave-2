namespace Obl_opgave_1
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Price { get; set; }

        public void ValidateBook()
        {
            ValidatePrice();
            ValidateTitle();
        }

        public void ValidateTitle()
        {
            if(Title==null)
            {
                throw new ArgumentNullException();
            }
            if(Title.Count()<3)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void ValidatePrice()
        {
            if(0>Price)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if(1200<=Price)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public override string ToString()
        {
            return $" Id: {Id} Title: {Title} Price: {Price}";
        }

    }
}