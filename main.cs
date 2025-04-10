using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory
{
  class Program
  {
    static void Main()
    {
      Console.WriteLine("Матричный калькулятор.");

      Console.WriteLine("Введите размер первой матрицы (строки x столбцы):");
      int sizeX1 = int.Parse(Console.ReadLine());
      int sizeY1 = int.Parse(Console.ReadLine());
      Matrix matrix1 = new Matrix(sizeX1, sizeY1);

      Console.WriteLine("Введите размер второй матрицы (строки x столбцы):");
      int sizeX2 = int.Parse(Console.ReadLine());
      int sizeY2 = int.Parse(Console.ReadLine());
      Matrix matrix2 = new Matrix(sizeX2, sizeY2);

      Console.WriteLine("\nПервая матрица:");
      Console.WriteLine(matrix1.ToString());

      Console.WriteLine("\nВторая матрица:");
      Console.WriteLine(matrix2.ToString());

      while (true)
      {
        Console.WriteLine("\nВыберите операцию:");
        Console.WriteLine("1 - +");
        Console.WriteLine("2 - *");
        Console.WriteLine("3 - >");
        Console.WriteLine("4 - <");
        Console.WriteLine("5 - <=");
        Console.WriteLine("6 - >=");
        Console.WriteLine("7 - ==");
        Console.WriteLine("8 - !=");
        Console.WriteLine("9 - Приведение к double");
        Console.WriteLine("10 - true");
        Console.WriteLine("11 - false");
        Console.WriteLine("12 - Детерминант");
        Console.WriteLine("13 - Транспонирование");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
          case 1:
            try
            {
              Matrix sum = matrix1 + matrix2;
              Console.WriteLine("\nРезультат сложения:");
              Console.WriteLine(sum.ToString());
            }
            catch (MatrixSizeMismatchException)
            {
              Console.WriteLine("\nРазмеры матриц не совпадают для сложения.");
            }
            break;

          case 2:
            try
            {
              Matrix product = matrix1 * matrix2;
              Console.WriteLine("\nРезультат умножения:");
              Console.WriteLine(product.ToString());
            }
            catch (MatrixSizeMismatchException)
            {
              Console.WriteLine("\nРазмеры матриц не совпадают для умножения.");
            }
            break;

          case 3:
            try
            {
              Matrix product = matrix1 > matrix2;
              Console.WriteLine("\nРезультат сравнения ">":");
              Console.WriteLine(product.ToString());
            }
            catch (MatrixSizeMismatchException)
            {
              Console.WriteLine("\nРазмеры матриц не совпадают для операции '>'.");
            }
            break;

          case 4:
            try
            {
              Matrix product = matrix1 < matrix2;
              Console.WriteLine("\nРезультат сравнения "<":");
              Console.WriteLine(product.ToString());
            }
            catch (MatrixSizeMismatchException)
            {
              Console.WriteLine("\nРазмеры матриц не совпадают для операции '<'.");
            }
            break;

          case 5:
            try
            {
              Matrix product = matrix1 <= matrix2;
              Console.WriteLine("\nРезультат сравнения "<=":");
              Console.WriteLine(product.ToString());
            }
            catch (MatrixSizeMismatchException)
            {
              Console.WriteLine("\nРазмеры матриц не совпадают для операции '<='.");
            }
            break;

          case 6:
            try
            {
              Matrix product = matrix1 >= matrix2;
              Console.WriteLine("\nРезультат сравнения ">=":");
              Console.WriteLine(product.ToString());
            }
            catch (MatrixSizeMismatchException)
            {
              Console.WriteLine("\nРазмеры матриц не совпадают для операции '>='.");
            }
            break;

          case 7:
            try
            {
              Matrix product = matrix1 == matrix2;
              Console.WriteLine("\nРезультат сравнения "==":");
              Console.WriteLine(product.ToString());
            }
            catch (MatrixSizeMismatchException)
            {
              Console.WriteLine("\nРазмеры матриц не совпадают для операции '=='.");
            }
            break;

          case 8:
            try
            {
              Matrix product = matrix1 != matrix2;
              Console.WriteLine("\nРезультат сравнения "!=":");
              Console.WriteLine(product.ToString());
            }
            catch (MatrixSizeMismatchException)
            {
              Console.WriteLine("\nРазмеры матриц не совпадают для операции '!='.");
            }
            break;

          case 9:
            try
            {
              Matrix product = (double)matrix1;
              Console.WriteLine("\nРезультат приведения к double:");
              Console.WriteLine(product.ToString());
            }
            catch (MatrixSizeMismatchException)
            {
              Console.WriteLine("\nОшибка.");
            }
            break;

          case 10:
            try
            {
              Matrix product = matrix1 == true;
              Console.WriteLine("\nРезультат "true":");
              Console.WriteLine(product.ToString());
            }
            catch (MatrixSizeMismatchException)
            {
              Console.WriteLine("\nОшибка.");
            }
            break;

          case 11:
            try
            {
              Matrix product = matrix1 == false;
              Console.WriteLine("\nРезультат "false":");
              Console.WriteLine(product.ToString());
            }
            catch (MatrixSizeMismatchException)
            {
              Console.WriteLine("\nРазмеры матриц не совпадают для операции '>='.");
            }
            break;

          case 12:
            try
            {
              Matrix product = Matrix.Determinant(matrix1);
              Console.WriteLine("\nРезультат детерминирования:");
              Console.WriteLine(product.ToString());
            }
            catch (MatrixSizeMismatchException)
            {
              Console.WriteLine("\nРазмеры матриц не совпадают для операции '>='.");
            }
            break;

          case 13:
            try
            {
              Matrix product = Matrix.Transoration(matrix1);
              Console.WriteLine("\nРезультат траспонирования:");
              Console.WriteLine(product.ToString());
            }
            catch (MatrixSizeMismatchException)
            {
              Console.WriteLine("\nРазмеры матриц не совпадают для операции '>='.");
            }
            break;

          case 0:
            Console.WriteLine("\nВыход из программы.");
            return;

          default:
            Console.WriteLine("\nНеверный выбор, попробуйте снова.");
            break;
        }
      }
    }
  }

  class MatrixSizeMismatchException : Exception
  {
    public MatrixSizeMismatchException() : base("Matrix sizes do not match!") { }
  }
  class ObjectTypeIsNotMatrix : Exception
  {
    public ObjectTypeIsNotMatrix() : base("It's not matrix!") { }
  }
  class Matrix: ICloneable
  {
    public int[,] value;
    public int sizeX, sizeY;

    public Matrix(int sizeX, int sizeY)
    {
        this.sizeX = sizeX;
        this.sizeY = sizeY;
        value = new int[sizeX, sizeY];
        Random random = new Random();
        
        for (int i = 0; i < sizeX; ++i)
            for (int j = 0; j < sizeY; ++j)
                value[i, j] = random.Next(-10, 10);
    }
    public object Clone()
    {
        Matrix copy = new Matrix(sizeX, sizeY);
        for (int i = 0; i < sizeX; ++i)
            for (int j = 0; j < sizeY; ++j)
                copy.value[i, j] = this.value[i, j];
        
        return copy;
    }
    public Matrix operator +(Matrix matrix1, Matrix matrix2)
    {
      if (matrix1.Size != matrix2.Size) throw new MatrixSizeMismatchException();
      Matrix result = new Matrix();
      for (int i = 0; i < sizeX; ++i)
      {
        for (int j = 0; j < sizeY; ++j)
        {
          result.value[i, j] = matrix1.value[i, j] + matrix2.value[i, j];
        }
      }
      return result;
    }
    
    public Matrix operator *(Matrix matrix1, Matrix matrix2)
    {
      if (matrix1.Size != matrix2.Size) throw new MatrixSizeMismatchException();
      Matrix result = new Matrix();
      for (int i = 0; i < sizeX; ++i)
      {
        for (int j = 0; j < sizeY; ++j)
        {
          result.value[i, j] = matrix1.value[i, j] * matrix2.value[i, j];
        }
      }
      return result;
    }
    public bool operator >(Matrix matrix1, Matrix matrix2)
    {
      if (matrix1.Size != matrix2.Size) throw new MatrixSizeMismatchException();
      int sum1 = 0;
      int sum2 = 0;
      for (int i = 0; i < sizeX; ++i)
      {
        for (int j = 0; j < sizeY; ++j)
        {
          sum1 += matrix1.value[i, j];
          sum2 += matrix2.value[i, j];
        }
      }
      return sum1 > sum2;
    }
    public bool operator <(Matrix matrix1, Matrix matrix2)
    {
      if (matrix1.Size != matrix2.Size) throw new MatrixSizeMismatchException();
      int sum1 = 0;
      int sum2 = 0;
      for (int i = 0; i < sizeX; ++i)
      {
        for (int j = 0; j < sizeY; ++j)
        {
          sum1 += matrix1.value[i, j];
          sum2 += matrix2.value[i, j];
        }
      }
      return sum1 < sum2;
    }
    public bool operator <=(Matrix matrix1, Matrix matrix2)
    {
      if (matrix1.Size != matrix2.Size) throw new MatrixSizeMismatchException();
      int sum1 = 0;
      int sum2 = 0;
      for (int i = 0; i < sizeX; ++i)
      {
        for (int j = 0; j < sizeY; ++j)
        {
          sum1 += matrix1.value[i, j];
          sum2 += matrix2.value[i, j];
        }
      }
      return sum1 <= sum2;
    }
    public bool operator >=(Matrix matrix1, Matrix matrix2)
    {
      if (matrix1.Size != matrix2.Size) throw new MatrixSizeMismatchException();
      int sum1 = 0;
      int sum2 = 0;
      for (int i = 0; i < sizeX; ++i)
      {
        for (int j = 0; j < sizeY; ++j)
        {
          sum1 += matrix1.value[i, j];
          sum2 += matrix2.value[i, j];
        }
      }
      return sum1 >= sum2;
    }
    public bool operator ==(Matrix matrix1, Matrix matrix2)
    {
      if (matrix1.Size != matrix2.Size) throw new MatrixSizeMismatchException();
      int sum1 = 0;
      int sum2 = 0;
      for (int i = 0; i < sizeX; ++i)
      {
        for (int j = 0; j < sizeY; ++j)
        {
          sum1 += matrix1.value[i, j];
          sum2 += matrix2.value[i, j];
        }
      }
      return sum1 == sum2;
    }
    public bool operator !=(Matrix matrix1, Matrix matrix2)
    {
      if (matrix1.Size != matrix2.Size) throw new MatrixSizeMismatchException();
      int sum1 = 0;
      int sum2 = 0;
      for (int i = 0; i < sizeX; ++i)
      {
        for (int j = 0; j < sizeY; ++j)
        {
          sum1 += matrix1.value[i, j];
          sum2 += matrix2.value[i, j];
        }
      }
      return sum1 != sum2;
    }
    public explicit operator double[,](Matrix matrix)
    {
      double[,] result = new double[sizeX, sizeY];
      for (int i = 0; i < sizeX; ++i)
      {
        for (int j = 0; j < sizeY; ++j)
        {
          result[i, j] = matrix.value[i, j];
        }
      }
      return result;
    }
    public bool operator true(Matrix matrix)
    {
      Matrix result = new Matrix();
      int sum = 0;
      for (int i = 0; i < sizeX; ++i)
      {
        for (int j = 0; j < sizeY; ++j)
        {
          sum += matrix.value[i, j];
        }
      }
      if (sum != 0) {
        return true;
      }
      else {
        return false;
      }
    }
    public bool operator false(Matrix matrix)
    {
      Matrix result = new Matrix();
      int sum = 0;
      for (int i = 0; i < sizeX; ++i)
      {
        for (int j = 0; j < sizeY; ++j)
        {
          sum += matrix.value[i, j];
        }
      }
      if (sum == 0)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    public int Determinant(Matrix matrix)
    {
      int result = 0;
      for (int i = 0; i < sizeX; ++i)
      {
        for (int j = 0; j < sizeY; ++j)
        {
          result *= matrix.value[i, j];
        }
      }
      return result;
    }
    public Matrix Transporation(Matrix matrix)
    {
      Matrix result = new Matrix();
      for (int i = 0; i < matrix.sizeX; ++i) {
        for (int j = 0; j < matrix.sizeY; ++j) {
          result.value[i, j] = matrix.value[j, i];
        }
      }
      return result;
    }

    public override string ToString()
    {
      string result = "";
      for (int i = 0; i < sizeX; ++i)
      {
        for (int j = 0; j < sizeY; ++j)
        {
          result += ToString(matrix[i, j]);
        }
        result += "\n";
      }
      return result;
    }

    public override int CompareTo(Matrix otherMatrix)
    {
      int sum1 = 0;
      int sum2 = 0;
      for (int i = 0; i < sizeX; ++i)
      {
        for (int j = 0; j < sizeY; ++j)
        {
          sum1 += value[i, j];
          sum2 += otherMatrix.value[i, j];
        }
      }
      return sum1.CompareTo(sum2);
    }

    public override bool Equals(object obj)
    {
      if (!(obj is Matrix)) throw new ObjectTypeIsNotMatrix();
      if (obj == value)
      {
        return true;
      }
      else{
        return false;
      }

    }
    public override int GetHashCode(){
      return Determinant(matrix);
    }
  }
}

public static class MatrixExtension() {
  public static Matrix Transpose(this Matrix matrix) {
    for (int i = 0; i < matrix.sizeX; ++i) {
      for (int j = 0; j < matrix.sizeY; ++j) {
        matrix[i, j] = matrix[j, i];
      }
    }
  }

  public static int TraceOfMatrix(Matrix matrix) {
    int result = 0;
    for (int i = 0; i < matrix.sizeX; ++i) {
      for (int j = 0; j < matrix.sizeY; ++j) {
        if (i == j) {
          result += matrix[i, j];
        }
      }
    }
    return result;
  }
}

Func<Matrix, Matrix> toDiagonal = matrix =>
{
  Matrix result = new Matrix();
  for (int i = 0; i < matrix.sizeX; ++i) {
    for (int j = 0; j < matrix.sizeY; ++j) {
      if (i != j){
        result[i, j] = 0;
      }
    }
  }
  return result;
}
