using SharedKernel.LinkedList.SinglyLinkedList;
using SharedKernel.Logging;

namespace ConsoleApp;

public class Program
{
    public static IEnumerable<Student> GetStudents()
    {
        return new List<Student>()
        {
            // new() { Id = Guid.NewGuid(), Name = "Student 1", DateOfBirth = DateTime.Now, Class = "1" },
            // new() { Id = Guid.NewGuid(), Name = "Student 2", DateOfBirth = DateTime.Now, Class = "2" },
            // new() { Id = Guid.NewGuid(), Name = "Student 3", DateOfBirth = DateTime.Now, Class = "1" },
            // new() { Id = Guid.NewGuid(), Name = "Student 4", DateOfBirth = DateTime.Now, Class = "3" },
            // new() { Id = Guid.NewGuid(), Name = "Student 5", DateOfBirth = DateTime.Now, Class = "5" },
            // new() { Id = Guid.NewGuid(), Name = "Student 6", DateOfBirth = DateTime.Now, Class = "1" }
        };
    }

    public static SinglyLinkedList<Student> InitSinglyLinkedList(IEnumerable<Student> students)
    {
        SinglyLinkedList<Student> linkedList = new SinglyLinkedList<Student>();
        foreach (var student in students)
        {
            linkedList.AddLast(student);
        }

        return linkedList;
    }

    public static void Main(string[] args)
    {
        var linkedList = InitSinglyLinkedList(GetStudents());
        try
        {
            linkedList.RemoveLast();
        }
        catch (Exception e)
        {
            Logging.Error(e.Message);
        }
        linkedList.DisplayWithCondition(x => true, x => Console.WriteLine($"{x.Id} - {x.Name}"));
    }
}

