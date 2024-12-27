# SpecFlow Selenium Framework

## Overview

This repository contains a **SpecFlow** Selenium framework that uses **Dependency Injection** and **Page Object Model (POM)** pattern for testing web applications and also support **Parallel Execution** . The framework is designed to be used with the following technologies:

- **SpecFlow** (BDD for C#)
- **Selenium WebDriver** (for browser automation)
- **NUnit 4.x** (for test execution)
- **Extent Report** (for reporting)
- **SpecFlow.DependencyInjection** (for generating documentation from SpecFlow features)
- **log4net** (for maintaining logs)
- **Newtonsoft.Json** (for working with Json file)
- **Takes screenshots on test failure**

The framework supports automation for **Parallel Execution** and is easily extendable for various web application testing needs.

---

## Features

- **BDD with SpecFlow**: Write tests using natural language (Gherkin syntax) and automate them using Selenium WebDriver.
- **Page Object Model**: Helps organize test code and maintain scalability by separating UI elements and actions into reusable classes.
- **Cross-browser Testing**: Support for Chrome, Internet Explorer (IE), and Edge browsers.
- **Enhanced Reporting**: Using Extent Report for maintaing the Testcase Step and log into an HTML.
- **Screenshots on Failure**: Automatically takes screenshots on test failure for better debugging.
- **Log Generation**: Generate Log even in Parallel execution , it uses shared log startegy for maintain logs

---

## Background Reading

- [Getting Started with SpecFlow](http://ralucasuditu-softwaretesting.blogspot.co.uk/2015/06/write-your-first-test-with-specflow-and.html?m=1)
- [SpecRun Blog for Enhanced Reporting](http://tech.opentable.co.uk/blog/2013/06/07/getting-started-with-specrun/)
  
---

## Getting Started

### Prerequisites

1. **Visual Studio**: Ensure you have **Visual Studio 2015 (Enterprise)** installed.
2. **NuGet Package Manager**: Install **NuGet** to manage project dependencies. You can read more about it here: [NuGet Package Manager](http://docs.nuget.org/consume/package-manager-dialog#managing-packages-for-the-solution).

### Setting Up the Project

1. **Clone the GitHub Repository**: Connect to the GitHub project (use `View > Team Explorer`).
2. **Install Dependencies** using NuGet:
   - **NUnit**: Version 2.6.47
   - **NUnit.Runners**
   - **NUnitTestAdaptor**
   - **SpecFlow**
   - **SpecFlow.NUnit**
   - **Selenium WebDriver**
     - Install Selenium via [NuGet Must Haves](http://nugetmusthaves.com/Tag/selenium)
   - **Selenium Support Package**

3. **Download WebDriver Drivers**:
   - Create a folder named `dependencies` in the project.
   - Download the appropriate drivers (Chrome, IE, Edge) via **NuGet** packages.
   - Right-click on `chromedriver.exe`, select **Properties**, and ensure:
     - **Build Action** is set to **Content**.
     - **Copy to Output Directory** is set to **Copy Always**.
   - This ensures that the `chromedriver.exe` is placed in the output directory for proper execution.

4. **Install SpecFlow Extension in Visual Studio**:
   - Go to `Tools > Extensions and Updates > Online`.
   - Search for **SpecFlow** and install the extension. Restart Visual Studio after installation.




