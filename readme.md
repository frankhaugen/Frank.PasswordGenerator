![Pipeline](https://github.com/frankhaugen/Frank.PasswordGenerator/workflows/Pipeline/badge.svg)
# Password Generator
This simple yet versetile Nuget package balances options with simplicity, delivering a fast way to add password generation. It uses .net standard 2.1, and is MIT -licenced

## Getting started
#### Install the Nuget package:

```
Install-Package Frank.PasswordGenerator
```
#### Then just implement the generator like so
```C#
var passwordGenerator = new PasswordGenerator();
var password = passwordGenerator.GeneratePassword(
    32,
    CharacterVariant.Lowercase,
    CharacterVariant.Digits,
    CharacterVariant.Uppercase);
Console.WriteLine(password);
```
See the "Cli"-project for a more extensive example
## About
This was just a small thing I did for fun and it seemed vaguely useful to others, so I added it as a Nuget for people, and myself to use

Using this should generate really good passwords just using it's defaults, but I have exposed the character length in a constant to allow developers to show this to their users, because sometimes business rules demands certain character lengths.

This library does not conform to any standards, nor does it provide any guarantees regarding security. Please examine source code to see if this library matches your security needs before releasing to production.

## Future features
This project is more or less "done" from my perspective, but feel free to request features by filing an issue.

Features I am concidering:
- Complexity calculations (calculating some kind of score to give feedback on complexity; that can be used seperatly)
- Option to remove "Homoglyphs" (Characters like O0Il1 that can be confused in a lot of fonts or by people with dyselxia)

## Password rules
Because security is vital in modern times, heres Microsoft's recommandations for password policies
>- Maintain an 8-character minimum length requirement (and longer is not necessarily better)
>- Eliminate character-composition requirements
>- Eliminate mandatory periodic password resets for user accounts
>- Ban common passwords, to keep the most vulnerable passwords out of your system
> Educate your users not to re-use their password for non-work-related purposes
>- Enforce registration for multi-factor authentication
>- Enable risk based multi-factor authentication challenges

Source: https://docs.microsoft.com/en-us/microsoft-365/admin/misc/password-policy-recommendations?view=o365-worldwide
