This is a collection of simple demos of coding practices.

These demos are purposely written in a simple and clear style. You will find no difficulty in following them to learn the powerful library.

## How to use

First copy the repo into your disk.

```bash
$ git clone https://github.com/rolee15/demo.git
```

Then play with the source files under the repo's directories.

## Folder structure

- `00_Init`   Initial stage of code
- `0X_StepX`  Steps to get to the final stage
- `0N_Final`  Final stage of the code
- `start`     working directory, initially it contains the contents of 00_Init

## Index

1. [TestableConsoleApp](#demo01-testableconsoleapp)

---

## Demo01: TestableConsoleApp

We have a function in Console.cs we want to test, but it uses concrete objects, so it is impossible to write unit tests for it.
In a few steps, we replace those objects with abstractions, and write tests with mocks of those objects.

