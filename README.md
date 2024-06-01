# Calculator for calculating matrices 🦋

This application will help you with the most common matrix operations.

> [!TIP]
> Use it on tests to check your calculations :)

## Functionality of the application:

1. **Basic arithmetic operations**
   - addition
   - subtraction
   - multiplication
   - division
   - equality check
   - multiplication by a scalar
   - exponentiation

2. **Trigonometric operations**
   - exponent of the elements
   - the logarithm of the elements
   - sine elements
   - cosine elements
   - tangent elements

3. **Transformation operations**
   - Transposed matrix
   - Inverse matrix
   - Permutation of matrix columns
   - Permutation of matrix rows
   - Rotating the Matrix

4. **Determinants / Characteristic Numbers Operations**
   - Determinant
   - Minimal element
   - Maximum element
   - Matrix norm
   - Sum of elements
   - Rank
   - Trace of the Matrix
   - Product of elements
   - Average value

  ## Using the Interface:

1. Select the matrix size using the "Rows" and "Columns" fields.
2. Enter the values of the matrix elements into the corresponding fields.
3. Select the required operation or multiple operations using the checkboxes.
4. Click the "Calculate" button to perform the operations.
5. The calculation results will be displayed in the "Result" section 🔥

   
> [!IMPORTANT]
> ### About implementation of the application ✏️

## Principles of programming

1. **KISS** - (Keep it simple, stupid)

   - Each class has a separate responsibility, making the code easier to understand and maintain. Methods are kept short and focused on a single task, such as the Execute methods in operation classes like `AddOperation` and `SubtractOperation`.

   ```csharp
   
     public class AddOperation : MatrixBinaryOperationBase
     {
         public AddOperation() : base(new SameSizeValidator()) { }

         protected override double PerformOperation(double valueA, double valueB)
         {
             return valueA + valueB;
         }
     }
   
   ```
   
   ```csharp
   
     public class SubtractionOperation : MatrixBinaryOperationBase
     {
          public SubtractionOperation() : base(new SameSizeValidator()) { }

          protected override double PerformOperation(double valueA, double valueB)
          {
              return valueA - valueB;
          }
      }
   
   ```

2. **DRY** - (Don't repeat yourself)

   - Matrix size validation is encapsulated in specific validator classes (FixedSizeMatrixValidator, SameSizeValidator, MultiplicationSizeValidator), which are reused across different matrix operations to avoid duplication of validation logic.

   ```csharp
   
   public class SameSizeValidator : IMatrixSizeValidator
   {
       public void Validate(IMatrix matrixA, IMatrix matrixB)
       {
           if (matrixA.Rows != matrixB.Rows || matrixA.Columns != matrixB.Columns)
           {
               MessageBoxHelper.Show("Matrices must have the same dimensions for this operation.");
               return;
           }
       }
   }
   
   ```
   - Common functionalities for matrix operations are abstracted into base classes like MatrixAggregateOperationBase, MatrixUnaryOperationBase, and MatrixBinaryOperationBase. These base classes handle common logic, allowing derived classes to focus on specific details.

    ```csharp
   
     public abstract class MatrixAggregateOperationBase : IMatrixOperation<double>
     {
        protected abstract double Initialize();
        protected abstract double Aggregate(double accumulator, double value);
        protected abstract double Finalize(double accumulator, int elementCount);
        public double Execute(IMatrix matrix)
        {
            double accumulator = Initialize();
            int elementCount = matrix.Rows * matrix.Columns;
            var iterator = new MatrixIterator(matrix);

            iterator.Iterate((i, j, value) =>
            {
                accumulator = Aggregate(accumulator, value);
            });

            return Finalize(accumulator, elementCount);
        }
    }

   ```
3. Fail Fast

   - Validators such as FixedSizeMatrixValidator, SameSizeValidator, MultiplicationSizeValidator, and SquareMatrixValidator check matrix dimensions and immediately display error messages if dimensions are incorrect.

   ```csharp
   
      public class FixedSizeMatrixValidator : IFixedSizeMatrixValidator
      {
          public void Validate(IMatrix matrix, int requiredRows, int requiredColumns)
          {
              if (matrix.Rows != requiredRows || matrix.Columns != requiredColumns)
              {
                  MessageBoxHelper.Show($"Matrix must be {requiredRows}x{requiredColumns}.");
                  return;
              }
          }
     }
   
   ``` 
   - In `MatrixContext`, an error message is shown if the operation strategy is not set before executing an operation.

    ```csharp
    
    public T ExecuteOperation<T>(IMatrix matrix)
    {
        if (_strategy is IMatrixOperation<T> operation)
        {
            return operation.Execute(matrix);
        }
        MessageBoxHelper.Show("Operation strategy is not set.");
        return default(T);
    }
    
    ```
   - In methods where certain conditions need to be met for further execution, early return statements are used to exit the method if the conditions are not satisfied.

    ```csharp
    
    public static void SetMatrixValues(TextBoxMatrix textBoxMatrix, double[,] matrix)
    {
        if (textBoxMatrix == null)
        {
            MessageBoxHelper.Show($"{nameof(textBoxMatrix)}");
            return;
        }

        if (matrix == null)
        {
            MessageBoxHelper.Show($"{nameof(matrix)}");
            return;
        }

        if (!IsMatrixSizeValid(textBoxMatrix, matrix))
        {
            MessageBoxHelper.Show("Incorrect dimensions of the matrix.");
            return;
        }

        var iterator = new MatrixIterator(new TextBoxMatrixWrapper(textBoxMatrix));
        iterator.Iterate((row, col, value) =>
        {
            textBoxMatrix.DataInputs[row, col].Text = matrix[row, col].ToString("F2");
        });
    }
    
    ```
    ### SOLID Principles

    #### S (Single Responsibility Principle)

     - Each class is responsible for a single part of the functionality. For example:

   **Matrix**: Responsible only for matrix data storage and retrieval.

    ```csharp

    public class Matrix : IMatrix
    {
        public double[,] MatrixArray { get; private set; }
        public int Rows => MatrixArray.GetLength(0);
        public int Columns => MatrixArray.GetLength(1);

        public Matrix(int rows, int columns, double[,] matrixArray = null)
        {
            MatrixArray = matrixArray ?? new double[rows, columns];
        }
    }
        ```
   **WinFormsUIFactory**: Responsible for creating UI elements.

    ```csharp
    
    public class WinFormsUIFactory : IUIFactory
    {
        public ILabel CreateLabel()
        {
            return new WinFormsLabel();
        }

        public ILabelService CreateLabelService()
        {
            return new WinFormsLabelService();
        }
    }
    ```
   #### O (Open/Closed Principle)


    - Classes are open for extension but closed for modification. For example:

    **MatrixUnaryOperationBase** and **MatrixBinaryOperationBase** can be inherited to implement specific operations without changing the base class code.

    ```csharp
    
    public abstract class MatrixUnaryOperationBase : IMatrixOperation<IMatrix>
    {
        private readonly IUnaryMatrixSizeValidator? _sizeValidator;

        protected MatrixUnaryOperationBase(IUnaryMatrixSizeValidator? sizeValidator = null)
        {
            _sizeValidator = sizeValidator;
        }

        protected abstract double PerformOperation(double value);

        public IMatrix Execute(IMatrix matrix)
        {
            _sizeValidator?.Validate(matrix);
            var result = new double[matrix.Rows, matrix.Columns];
            var iterator = new MatrixIterator(matrix);

            iterator.Iterate((i, j, value) =>
            {
                result[i, j] = PerformOperation(value);
            });

            return new Matrix(matrix.Rows, matrix.Columns, result);
        }
    }
    
    ```
     Example of extending `MatrixUnaryOperationBase` for a specific operation:

    ```csharp
    public class ExpOperation : MatrixUnaryOperationBase
    {
        protected override double PerformOperation(double value)
        {
            return Math.Exp(value);
        }
    }
    ```
    #### L (Liskov Substitution Principle)

     - All classes implementing interfaces can be replaced by these interfaces without affecting the correctness of the program. These classes can be used interchangeably where IUnaryMatrixSizeValidator is expected.

     **IUnaryMatrixSizeValidator** and its implementations:

    ```csharp
    
    public interface IUnaryMatrixSizeValidator
    {
        void Validate(IMatrix matrix);
    }

    public class SquareMatrixValidator : IUnaryMatrixSizeValidator
    {
        public void Validate(IMatrix matrix)
        {
            if (matrix.Rows != matrix.Columns)
            {
                MessageBoxHelper.Show("Matrix must be square.");
            }
        }
    }

    public class FixedSizeMatrixValidator : IUnaryMatrixSizeValidator
    {
        private readonly int _requiredRows;
        private readonly int _requiredColumns;

        public FixedSizeMatrixValidator(int requiredRows, int requiredColumns)
        {
            _requiredRows = requiredRows;
            _requiredColumns = requiredColumns;
        }

        public void Validate(IMatrix matrix)
        {
            if (matrix.Rows != _requiredRows || matrix.Columns != _requiredColumns)
            {
                MessageBoxHelper.Show($"Matrix must be {_requiredRows}x{_requiredColumns}.");
            }
        }
    }
    
    ```
    #### I (Interface Segregation Principle)


     - Interfaces are split into smaller, more specific parts. For example:

     **IMatrixOperation**, **IMatrixBinaryOperation**, **IUnaryMatrixSizeValidator**:

    ```csharp
    public interface IMatrixOperation<T>
    {
        T Execute(IMatrix matrix);
    }  

    public interface IMatrixBinaryOperation : IMatrixOperation<IMatrix>
    {
        IMatrix Execute(IMatrix matrixA, IMatrix matrixB);
    }

    public interface IUnaryMatrixSizeValidator
    {
        void Validate(IMatrix matrix);
    }

    public interface IMatrixSizeValidator
    {
        void Validate(IMatrix matrixA, IMatrix matrixB);
    }
    ```
    This allows classes to implement only the methods they need, adhering to the ISP:

    ```csharp
    public class FixedSizeMatrixValidator : IUnaryMatrixSizeValidator
    {
        public void Validate(IMatrix matrix)
        {
            if (matrix.Rows != 3 || matrix.Columns != 3)
            {
                MessageBoxHelper.Show("Matrix must be 3x3.");
            }
        }
    }

    public class SameSizeValidator : IMatrixSizeValidator
    {
        public void Validate(IMatrix matrixA, IMatrix matrixB)
        {
            if (matrixA.Rows != matrixB.Rows || matrixA.Columns != matrixB.Columns)
            {
                MessageBoxHelper.Show("Matrices must have the same dimensions.");
            }
        }
    }
    ```
     #### D (Dependency Inversion Principle)


     - Abstractions do not depend on details. For example:

     Factory Classes create instances of interfaces, promoting the use of abstractions over concrete implementations:
   
    ```csharp
    public interface IDataInputFactory
    {
        IDataInput CreateDataInput();
    }

    public class WinFormDataInputFactory : IDataInputFactory
    {
        public IDataInput CreateDataInput()
        {
            return new WinFormTextBox();
        }
    }
    ```
     Client code depends on the abstraction `IDataInputFactory`:

    ```csharp
    
    public class MatrixUI
    {
        private readonly IDataInputFactory _dataInputFactory;

        public MatrixUI(IDataInputFactory dataInputFactory)
        {
            _dataInputFactory = dataInputFactory;
        }

        public void CreateMatrixInputs(int rows, int columns)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    IDataInput input = _dataInputFactory.CreateDataInput();
                    //...
                }
            }
        }
    }
    ```
   #### Composition Over Inheritance

     - The principle of "Composition Over Inheritance" is followed to build functionality more flexibly and reuse code effectively. Instead of relying solely on inheritance, the code uses composition to include various functionalities. For example, the `MatrixContext` class manages strategies for matrix operations through composition, allowing different strategies to be set and executed dynamically. Additionally, validator classes like `FixedSizeMatrixValidator` are used in composition with matrix operations to ensure constraints are met without requiring inheritance.

    #### Program to Interfaces, Not Implementations

     - This principle ensures that the code depends on abstractions (interfaces) rather than concrete implementations, providing greater flexibility and easier maintenance. For instance, the `MatrixContext` works with interfaces like `IMatrixOperation` and `IMatrixBinaryOperation`, allowing any class implementing these interfaces to be used interchangeably. Similarly, factory classes create instances of interfaces, promoting the use of abstractions over concrete implementations. This approach makes the code more modular and extensible.


## Design patterns

#### 1. Template Method 

> [!Note]
> Template Method Pattern is used to define the skeleton of an algorithm in a method, deferring some steps to subclasses. It allows subclasses to redefine certain steps of an algorithm without changing the algorithm's structure.

 - The main components of the "Template Method" pattern:
    - Abstract Class (MatrixAggregateOperationBase, MatrixUnaryOperationBase, MatrixBinaryOperationBase): These classes define the template method which outlines the skeleton of the algorithm. They contain abstract methods that are meant to be implemented by subclasses to complete the algorithm.
    * Concrete Classes: These classes extend the abstract class and implement the abstract methods to define the steps of the algorithm. Examples include CalculateSum, CalculateProduct, ExpOperation, LogOperation, AddOperation, SubtractionOperation, etc.

#### 2. Strategy

> [!Note]
> The Strategy Pattern is used to define a family of algorithms, encapsulate each one, and make them interchangeable. It allows the algorithm to vary independently from the clients that use it.
 - The main components of the "Strategy" pattern:
   * Strategy Interface (IMatrixOperation<T>, IMatrixBinaryOperation): Defines the operations that must be implemented by specific strategies.
   + Strategy Interface for Validation (IUnaryMatrixSizeValidator, IMatrixSizeValidator, IFixedSizeMatrixValidator): Defines the validation operations that must be implemented by specific validators.
   * Specific Strategies: Implement the strategy interface for operations. Examples include unary operations, binary operations, determinant calculations, etc.
   + Specific Strategies for Validation: Implement the strategy interface for validation. Examples include SquareMatrixValidator, SameSizeValidator, MultiplicationSizeValidator, FixedSizeMatrixValidator.
   * Context (MatrixContext): Stores a reference to the strategy object and its methods for operations.
   + Context (MatrixFacade): Uses different strategies and validators to simplify the interaction with matrix operations.

#### 3. Facade 

> [!Note]
> The Facade Pattern is used to provide a unified interface to a set of interfaces in a subsystem. It defines a higher-level interface that makes the subsystem easier to use.
 - The main components of the "Facade" pattern:
   - MatrixFacade: The main class that simplifies interactions with various matrix operations. It provides methods for common operations such as addition, subtraction, multiplication, inversion, determinant calculation, etc.

#### 4. Iterator  

> [!Note]
> The Iterator Pattern provides a way to access the elements of an aggregate object sequentially without exposing its underlying representation. In this project, the iterator pattern is implemented to iterate through elements of a matrix. 
 - The main components of the "Iterator" pattern:
   - Iterator Interface (IIterator): Defines the interface for accessing and traversing elements.
   + Concrete Iterator (MatrixIterator): Implements the iterator interface to traverse the elements of a matrix.
   - Aggregate Interface (IMatrix): Defines the interface for creating an iterator.
   + Concrete Aggregate (Matrix, TextBoxMatrixWrapper): Implements the aggregate interface and provides methods to create an iterator.

#### 5. Adapter   

> [!Note]
> The Adapter Pattern is used to convert the interface of a class into another interface that a client expects. It allows classes with incompatible interfaces to work together. In this project, the adapter pattern is implemented to work with text fields (TextBoxMatrix) as matrices. 
 - Components of the Adapter Pattern in this Project:
    + Target Interface (IMatrix): Defines the interface expected by the clients.
    - Adaptee (TextBoxMatrix): The class with an incompatible interface that needs to be used.
    + Adapter (TextBoxMatrixWrapper): The class that implements the target interface and wraps the adaptee, transforming its interface into a compatible one.

#### 6. Factory Pattern   

> [!Note]
> The Factory Pattern is used to create objects without specifying the exact class of the object that will be created. This allows for abstraction in the object creation process and provides flexibility in choosing implementations. 
 - Components of the Adapter Pattern in this Project:
    - Factory Interfaces (IUIFactory, IDataInputFactory, IControlManagerFactory): Define methods for creating objects.
    + Concrete Factories (WinFormDataInputFactory, WinFormControlManagerFactory, WinFormsUIFactory): Implement the factory interfaces and define the logic for creating specific objects.

  - Components Explanation:
   
    Factory Interfaces:
   
        - IUIFactory: Defines methods to create UI components like labels and label services.
        - IDataInputFactory: Defines a method to create data input components such as text boxes.
        - IControlManagerFactory: Defines a method to create control managers for managing UI controls.
   
    Concrete Factories:
   
        - WinFormDataInputFactory: Creates instances of data inputs.
        - WinFormControlManagerFactory: Creates instances of control managers.
        - WinFormsUIFactory: Creates instances of UI components.


## Refactoring Techniques

### 1. Extract Method
> **Note:** Extracting methods helps to improve code readability and maintainability by breaking down complex methods into smaller, more manageable ones.

- **Usage in Project:**
  - In classes such as `CalculateRank`, helper methods like `SwapRows` are used to enhance code readability and maintainability.

### 2. Replace Magic Number with Symbolic Constant
> **Note:** Replacing magic numbers with symbolic constants makes the code more understandable and easier to maintain.

- **Usage in Project:**
  - Constants are used for matrix dimensions across various classes, enhancing code clarity and simplifying maintenance.

### 3. Encapsulate Field
> **Note:** Encapsulating fields by making them private and providing public getters ensures controlled and safe access to the data.

- **Usage in Project:**
  - Fields are made private with public getters, ensuring controlled access to the data.

### 4. Delegation
> **Note:** Delegation involves passing responsibilities to other classes or methods, promoting flexibility and modularity.

- **Usage in Project:**
  - Delegates are utilized in classes like `MatrixContext` for dynamic execution of operations.

### 5. Use Meaningful Variable Names
> **Note:** Using meaningful names for variables and methods makes the code more intuitive and easier to understand.

- **Usage in Project:**
  - Variable and method names are thoughtfully chosen to clearly convey their purpose.

### 6. Introduce Null Object
> **Note:** Null checks are extensively used to prevent errors, often implemented through delegates or explicit checks to ensure robustness.

- **Usage in Project:**
  - Null checks are used to prevent errors, with delegates or checks applied for this purpose.
