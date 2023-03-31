namespace opeators

{


    /*   OPERATORS  - ARITHMETIC ,RELATIONAL ,LOGICAL,BITWISE,ASSINGMENT,CONDITIONAL.
     *   ARITHMETIC OPERATOR - addition,subraction,multiplication ,division,modulous.
     *   RELATIONAL OPERATOR - equals to,not equals to, greater than,less than,greater than or equals to,not greater than or equals to.
     *   LOGICAL OPERATOR - logicalAND,logicalOR ,logicalNOT.
     *   ASSINGMENT OPERATOR - simple ,complex
     *   CONDIITIONAL OPERATOR
     */

    public class Operators
    {


        public class OperatorArithmetic
        {
            // arithmetic operators - addition
            public void add(int x, int y)
            {
                // Displaying the addition solution
                Console.WriteLine("the addition of two numberss  {0} and {1} is {2} ", x, y, x + y);
            }
            // arithmetic operators - subraction
            public void sub(int x, int y)
            {
                // Displaying the subraction solution
                Console.WriteLine("the subraction of two numberss  {0} and {1} is {2} ", x, y, x - y);
            }
            // arithmetic operators - multiplication
            public void mul(int x, int y)
            {
                // Displaying the multiplication solution
                Console.WriteLine("the multiplication of two numberss  {0} and {1} is {2} ", x, y, x * y);
            }
            // arithmetic operators - division
            public void div(int x, int y)
            {
                // Displaying the division solution
                Console.WriteLine("the division of two numberss  {0} and {1} is {2} ", x, y, x / y);
            }
            // arithmetic operators - modulus
            public void mod(int x, int y)
            {
                // Displaying the modulo solution
                Console.WriteLine("the modulo of two numberss  {0} and {1} is {2} ", x, y, x % y);
            }
        }
        public class OperatorRelational
            {
                // Relational operator - Equals to
                public void equalsTo(int x, int y)
                {
                    // Displaying the Equals to operator 
                    Console.WriteLine("the first value {0} is equalsTo (==) the second value {1} - {2} ", x, y, x == y);
                }
                // Relational operator - notEquals to
                public void notEqualsTo(int x, int y)
                {
                    // Displaying the notEqualsTo to operator 
                    Console.WriteLine("the first value {0} is notEqualsTo (!=) the second value {1} - {2} ", x, y, x != y);
                }
                // Relational operator - geraterThan 
                public void greaterThan(int x, int y)
                {
                    // Displaying the geraterThan to operator 
                    Console.WriteLine("the first value {0} is geraterThan (>) the second value {1} - {2} ", x, y, x > y);
                }
                // Relational operator - lessThan 
                public void lessThan(int x, int y)
                {
                    // Displaying the lessThan  operator 
                    Console.WriteLine("the first value {0} is lessThan (<) the second value {1} - {2} ", x, y, x < y);
                }
                // Relational operator -  geraterThan  or equals to
                public void greaterThanEqualsTo(int x, int y)
                {
                    // Displaying the greaterThanEqualsTo  operator 
                    Console.WriteLine("the first value {0} is greaterThanEqualsTo (>=) the second value {1} - {2} ", x, y, x >= y);
                }
                // Relational operator -  lessThan  or equals to
                public void lessThanEqualsTo(int x, int y)
                {
                    // Displaying the lessThanEqualsTo  operator 
                    Console.WriteLine("the first value {0} is lessThanEqualsTo (<=) the second value {1} - {2} ", x, y, x <= y);
                }

            }
        public class OperatorLogical
            {
                // Logical operator -  AND
                public void logicalAND(bool x, bool y)
                {
                    //Displaying the logical AND operator
                    Console.WriteLine("the logical AND operator of {0} and {1} - {2} ", x, y, x && y);
                }
                // Logical operator -  OR
                public void logicalOR(bool x, bool y)
                {
                    //Displaying the logical OR operator
                    Console.WriteLine("the logical OR operator of {0} and {1} - {2} ", x, y, x || y);
                }
                // Logical operator -  NOT
                public void logicalNOT(bool x)
                {
                    //Displaying the logical NOT operator
                    Console.WriteLine("the logical NOT operator of {0} - {1}  ", x, !x);
                }
            }
        public class OperatorAssingnment
        {
            // Assingnment operator -  Equal
            public void equals(int x)
            { 
                //assingning the value of x to the y
                int y = x;
                //displaying the assingnment operator
                Console.WriteLine("the example of assingment operator - the value of y is {0} ",y);
            }
            // Assingnment operator -  add

            public void otherAsssingnment(int x)
            {
                //assingning the value of x to the y
                int y = x;
                y += x;
                //displaying the assingnment operator
                Console.WriteLine("the addAssingnment - {0}",y);
            }
        }
        public class ConditionalOperator
        {
            //Conditional operator

            //we can access static member without creating the object
           public static void ConditionalOperatorExample(int x)
            {
                int age = x;
                string result = (age >= 18) ? "Elligible to Vote" : "Inelligible to Vote";
                //Display the example of conditional operator
                Console.WriteLine(result);

            }
        }
        static void Main(string[] args)
        {
            //creating instance for OperatorArithmetic class
            OperatorArithmetic sample = new OperatorArithmetic();
            //passing arguments to the add method
            sample.add(1,2);
            //passing arguments to the sub method
            sample.sub(5,2);
            //passing arguments to the mul method
            sample.mul(4,4);
            //passing arguments to the div method
            sample.div(20,4);
            //passing arguments to the mod method
            sample.mod(10,3);


            //creating instance for OperatorRelational class
            OperatorRelational sample2 =new OperatorRelational();
            //passing arguments to the equalsTo method
            sample2.equalsTo(1,2);
            //passing arguments to the notEqualsto method
            sample2.notEqualsTo(3,3);
            //passing arguments to the lessthan method
            sample2.lessThan(2,4);
            //passing arguments to the graterthan method
            sample2.greaterThan(4,2);
            //passing arguments to the lessThanEqualsto method
            sample2.lessThanEqualsTo(2, 4);
            //passing arguments to the greaterThanEqualsTo method
            sample2.greaterThanEqualsTo(2, 4);
            //passing arguments to the lessThanEqualsTo method
            sample2.lessThanEqualsTo(2, 2);


            //creating instance for OperatorLogical class
            OperatorLogical sample3 =new OperatorLogical();
            //passing arguments to the logicalAND method
            sample3.logicalAND(true,false);
            //passing arguments to the logicalOR method
            sample3.logicalOR(true, false);
            //passing arguments to the logicalNOT method
            sample3.logicalNOT(true);


            //creating instance for OperatorAssingnment class
            OperatorAssingnment sample4 =new OperatorAssingnment();
            //passing arguments to the equals method
            sample4.equals(5);
            //passing arguments to the otherAsssingnment method
            sample4.otherAsssingnment(3);


                Operators.ConditionalOperator.ConditionalOperatorExample(42);
        }

    }
}