# C# 14 Audit (Console, .NET 10)

This repo is a deliberately conservative audit of features often claimed for “C# 14”. Each demo is labeled as **Final**, **Preview**, or **Baseline (earlier C#)** to avoid version drift. All outputs are purely to prove compiler behaviors.

## Environment
- .NET SDK: 10.x (preview channel recommended)
- LangVersion: `preview` (set in `What's new in C# 14.csproj`)
- Project type: Console

## Feature Classification
- Preview (C# 14):
  - Primary constructors on classes (requires `/langversion:preview`)
  - Ref readonly parameters in wider call patterns (treated as preview)
- Baseline (earlier C#; included for contrast, not “new” to 14):
  - Collection expressions with spread (`[]`, `..`) — C# 12
  - Default parameter values on lambdas — C# 12
  - Alias any type (including tuples) — C# 12

## Structure
```
/Features
  /FeatureName
    FeatureName.Before.cs   // prior pattern or limitation
    FeatureName.After.cs    // new/preview syntax
    FeatureName.Demo.cs     // prints before vs after evidence
Program.cs                  // runs all demos with status labels
```

## How to run
```bash
dotnet run
```
Output shows per-feature sections with `[PreviewCSharp14]` or `[BaselineEarlier]` labels and before/after evidence.

## Notes and Exclusions
- Only features that compile with the configured SDK are shown.
- Baseline items are kept to prevent mislabeling C# 12 features as “new in 14”.
- If your SDK lacks the preview bits for primary constructors on classes or widened ref readonly scenarios, keep `/langversion:preview` and use the latest .NET 10 previews.

