namespace GettersAndSetters
{
    //Encapsulation
    public class gettersAndSetters
    {
        // creating private feilds
        private int _id;
        private string _name;
        private int _passMark=35;

        // creating field with easy step
        // behind this its creats an department private filed and get set method.
        public string Department { get; set; }

        //setting id with condition
        public void setId(int id)
        {
            if(id <=0)
            {
                Console.WriteLine("the id cannot be negetive");
                throw new Exception("no negetive");
            }
            _id = id;
        }
        //for getting the id
        public int getId()
        {
            return _id;
        }
        //setting Name with condition
        public void setName(string name) 
        {
            // if the string is empty it throws some exeption
            if(string.IsNullOrEmpty(name))
            {
                // our exception with a string for understanding
                throw new Exception("name cannot be empty or null");
            }
            // else block 
            _name = name;
        }
        //for getting the name
        public string getName()
        {
            // condition for string is empty or not
            string check = string.IsNullOrEmpty(_name) ? "NO NAME" : _name;
            return check;

        }
        //for getting the pass mark
        public int getPass()
        {
            return _passMark;
        }
    }
    public class program
    {
        static void Main(string[] args)
        {
            //creating the instance
            gettersAndSetters obj = new gettersAndSetters();

            //setting id
            obj.setId(1);

            //setting name
            obj.setName("sudhar");

            //seting departnment
            obj.Department = "EIE";

            //for displaying id,name ,passmark,departnment
            Console.WriteLine("Id        : " + obj.getId());
            Console.WriteLine("Name      : " + obj.getName());
            Console.WriteLine("PassMark  : " + obj.getPass());
            Console.WriteLine("Department: " + obj.Department);

        }
    }
}