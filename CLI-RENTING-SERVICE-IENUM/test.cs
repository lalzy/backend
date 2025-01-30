public class Guest
{
    public string Name { get; set; }
    public int Age { get; set; }
}




public class Party : IEnumerable<Guest>
{
    private IList<Guest> _guestList;
 
    public Party()
    {
        _guestList = new List<Guest>();
    }
 
    public void AddGuest(Guest guest)
    {
        _guestList.Add(guest);
    }
 
    public IEnumerator<Guest> GetEnumerator()
    {
        foreach (Guest guest in _guestList)
        {
            yield return guest;
        }
    }
 
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}