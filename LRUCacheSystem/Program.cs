using LRUCacheSystem.Core;

Console.WriteLine("--- Initializing LRU Cache (Capacity = 3) ---");

var cache = new LruCache<string, int>(capacity: 3);


Console.WriteLine("\n--- PHASE 1: Simple Insertion ---");

cache.Put("A", 100); 
cache.Put("B", 200); 
cache.Put("C", 300); 

Console.WriteLine($"Current Cache Size: {cache.CurrenctCacheCapacity()}"); // Should be 3

Console.WriteLine($"A: {cache.Get("A")}"); // Output: 100

// --- PHASE 2: Access (Usage Update) ---

// Accessing 'A' moves it to the MRU position (head)
// Order changes from [C, B, A] to [A, C, B]
Console.WriteLine("\n--- PHASE 2: Access and Usage Update ---");
Console.WriteLine($"A accessed. New order: [A, C, B]");

// --- PHASE 3: Eviction ---

// Adding a new item 'D' forces the eviction of the LRU item, which is 'B'.
Console.WriteLine("\n--- PHASE 3: Eviction of LRU ---");
cache.Put("D", 400); // [D, A, C] (B is evicted)

Console.WriteLine($"B: {cache.Get("B")}"); // Output: 0 (or default(int), B was evicted)
Console.WriteLine($"D: {cache.Get("D")}"); // Output: 400

// Accessing 'C' moves it to MRU: [C, D, A]
Console.WriteLine($"C: {cache.Get("C")}"); // Output: 300
Console.WriteLine("C accessed. New order: [C, D, A]");

// Adding a new item 'E' forces the eviction of 'A'.
cache.Put("E", 500); // [E, C, D] (A is evicted)
Console.WriteLine("\nAdded E. A is evicted.");

Console.WriteLine($"A: {cache.Get("A")}"); // Output: 0 (A wa