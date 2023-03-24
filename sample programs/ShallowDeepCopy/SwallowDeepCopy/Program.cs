namespace ShallowDeepCopy
{
  
    public class Student
    {
        public int age { get; set; }
        public Teacher teacher { get; set; }

        public Student() 
        {
            age = 21;
            teacher= new Teacher();
        }
        public Student ShallowCopy()
        {
            return (Student)this.MemberwiseClone();
        }
        public Student DeepCopy()
        {
            Student student = new Student();
            student= (Student)this.MemberwiseClone();
            student.teacher = new Teacher() { salary = this.teacher.salary };
            return student;
        }

    }
    public class Teacher
      
    {
        public Teacher()
        {
          salary = 10000;
        }
        public int salary { get; set; }
    }

    public class program
    {
       
        static void Main(string[] args)
        {
           Student student1 = new Student() { };
           Student student2 = student1.ShallowCopy();
            Console.WriteLine("shallow");
            Console.WriteLine(  @" before changing  1st obj age: {0} salery :{1}   2nd obj age: {2} salery: {3}",
                                  student1.age,student1.teacher.salary,student2.age,student2.teacher.salary);
            
            student2.age= 26;
            student2.teacher.salary = 20000;
            Console.WriteLine(@" after changing  1st obj age: {0} salery :{1}   2nd obj age: {2} salery: {3}",
                                  student1.age, student1.teacher.salary, student2.age, student2.teacher.salary);
            Student student3= student1.DeepCopy();
            Console.WriteLine("deep");
            Console.WriteLine(@" before changing  1st obj age: {0} salery :{1}   2nd obj age: {2} salery: {3}",
                                  student1.age, student1.teacher.salary, student3.age, student3.teacher.salary);

            student3.age = 30;
            student3.teacher.salary = 60000;
            Console.WriteLine(@" after changing  1st obj age: {0} salery :{1}   2nd obj age: {2} salery: {3}",
                                  student1.age, student1.teacher.salary, student3.age, student3.teacher.salary);

        }



    }
}