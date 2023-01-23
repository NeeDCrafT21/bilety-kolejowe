namespace BackEndApplication;

public abstract class PreTimeTable
{
    protected char cityName;

    protected PreTimeTable(char name)
    {
        city = name;
    }
    public char city
    {
        get
        {
            return cityName;
        }

        set
        {
            cityName = value;
        }
    }

    public abstract void setTable(Task<List<Ride<TimeOnly>>> rides);
    public abstract void PrintTable();
    public abstract Task<List<Ride<TimeOnly>>> generateTable();

}