using ADO_Address_Book;

List<Address_Book_Model> list = new List<Address_Book_Model>();
Address_Book_Model model = new Address_Book_Model();
ManageAddressBook run = new ManageAddressBook();
Console.WriteLine("1 - To Add Data");
Console.WriteLine("2 - To Display Data");
Console.WriteLine("3 - To Update Data");
Console.WriteLine("4 - To Delete Person");
Console.WriteLine("5 - To Add Data Using Thread");
int option = Convert.ToInt32(Console.ReadLine());
switch (option)
{
    case 1:
        run.GetSetPersons(model);
        run.AddData(model);
        break;
    case 2:
        run.display();
        break;
    case 3:
        run.UpdateData();
        run.display();
        break;
    case 4:
        run.DeleteAddress();
        run.display();
        break;
    case 5:
        run.AddPersonUsingThread(list);
        break;
}




