AgileCoding.Extensions.String
=============================

Overview
--------

AgileCoding.Extensions.String is a .NET library that provides a suite of extension methods to enhance string behavior. It is built for .NET 6.0.

Installation
------------

This library is distributed via NuGet. To install it, use the NuGet package manager console:

bash

`Install-Package AgileCoding.Extensions.String -Version 2.0.5`

Features
--------

This library introduces several extension methods:

-   `ThrowIfNotContains`: Throws a specified exception if a string does not contain a given substring.
-   `ThrowIfContains`: Throws a specified exception if a string contains a given character.
-   `ThrowIfContainsCharacters`: Throws a specified exception if a string contains any character from a given set.
-   `ReplaceIfContains`: Replaces any occurrence of specified characters in a string with a replacement character.
-   `ThrowIfIsNullOrEmpty`: Throws specified exceptions if a string is null or empty.
-   `ToBytes`: Converts a string to a byte array using specified encoding.
-   `ToGuid`: Attempts to convert a string to a GUID.
-   `ToBase64`: Converts a string to a Base64 string.
-   `FromBase64`: Converts a Base64 string back to a byte array.

Usage
-----

Here's an example of how to use these methods in your code:

```csharp
using AgileCoding.Extentions.String;

string myString = "Hello, world!";

// Throws an exception if the string does not contain a substring.
myString.ThrowIfNotContains<InvalidOperationException>("world");

// Throws an exception if the string contains a character.
myString.ThrowIfContains<InvalidOperationException>(',');

// Convert a string to a byte array.
byte[] myByteArray = myString.ToBytes(Encoding.UTF8);
```

Documentation
-------------

For more detailed information about the usage of this library, please refer to the [official documentation](https://github.com/ToolMaker/AgileCoding.Extentions.String/wiki).

License
-------

This project is licensed under the terms of the MIT license. For more information, see the [LICENSE](https://github.com/ToolMaker/AgileCoding.Extentions.String/blob/main/LICENSE) file.

Contributing
------------

Contributions are welcome! Please see our [contributing guidelines](https://github.com/ToolMaker/AgileCoding.Extentions.String/blob/main/CONTRIBUTING.md) for more details.