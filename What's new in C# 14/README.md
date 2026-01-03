# Modern C# — Writing Cleaner, More Readable Code

**A practical guide to the expressive power of modern C# through simple Before/After comparisons.**

As C# evolves, it consistently moves toward a more expressive, concise, and readable syntax. The primary goal of these updates is to reduce "language ceremony"—the boilerplate code that often obscures a developer's true intent. 

This repository is designed as a clear, educational resource for developers at all levels. It focuses on the patterns that make our codebases easier to maintain and our logic easier to follow. By embracing these modern idioms, we can spend less time managing boilerplate and more time solving real-world problems.

## What This Repository Covers

Rather than focusing on technical version numbers, this project demonstrates fundamental shifts in how we write C# today:

*   **Primary Constructors**: Capturing state directly in the class signature to eliminate repetitive constructor bodies and manual property assignments.
*   **Collection Expressions**: Using a unified syntax (`[]`) with spread support (`..`) to build lists and arrays with significantly less visual noise.
*   **Default Lambda Parameters**: Declaring default values directly within inline expressions, removing the need for redundant helper methods or complex delegate wrappers.
*   **Intent-Driven Type Aliases**: Using descriptive aliases for complex shapes, such as tuples, to make method signatures self-documenting and readable.

## How to Use This Repository

This project is built as a self-guided tour of modern coding practices:

1.  **Explore the Code**: Navigate to the `Features` folder to see the "Before" and "After" implementations for each concept.
2.  **Run the Demonstration**: Execute the console application using `dotnet run`.
3.  **Compare the Output**: The console output is designed to be read alongside the code, showing you exactly how each feature simplifies the resulting logic.

## Project Structure

This repository is organized into feature-specific modules to help you navigate the changes easily:

*   **Program.cs**: The entry point of the application. It orchestrates the demonstration by running each feature's "Before" and "After" comparisons.
*   **Features/**: This directory contains the core educational content, subdivided by language feature:
    *   `*.Before.cs`: Shows the traditional way of achieving a result (pre-modern syntax).
    *   `*.After.cs`: Shows the modern, cleaner approach using recent C# enhancements.
    *   `*.Demo.cs`: Contains the logic used to display these changes in the console.
*   **IFeatureDemo.cs**: A simple interface that ensures a consistent structure across all feature demonstrations.

By comparing the `.Before.cs` and `.After.cs` files in each folder, you can see exactly how the new syntax reduces boilerplate and improves code clarity.

