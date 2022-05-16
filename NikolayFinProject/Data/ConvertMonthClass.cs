namespace NikolayFinProject.Data
{
    public class ConvertMonthClass
    {
        public static string ConvertMonth(int numberOfMonth)
        {
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September"
                    , "October", "November", "December" };
            string monthToReturn = months[numberOfMonth - 1];
            return monthToReturn;
        }
    }
}
