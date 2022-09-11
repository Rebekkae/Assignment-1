namespace Assignment1;

public static class Iterators {

    public static void Main(string[] args) {}
    public static IEnumerable<T> Flatten<T>(IEnumerable<IEnumerable<T>> items) {
        foreach (IEnumerable<T> i in items) {
             foreach (T j in i) {
                yield return j; 
             }
        }
    }

    public static IEnumerable<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate) {
        foreach (T i in items) {
            if(predicate(i)) {
                yield return i;
            }
        }
    }
}