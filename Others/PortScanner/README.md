# PortScanner
This application is a fully functional port scanner written in C# using Visual Studio 2015 and .NET 4.5.

## Description
This software allows you to scan a port or a range of ports. You specify an IP address or hostname, a port or a range of ports, select a protocol (TCP or UDP) and a timeout period. The application will then scan the ports and output the results in the main log window.

## Highlights
* Application built in OOP
* Asynchronous port scanning
* Cancel button allows stopping of port scanning operation

## Features
* Single port scanning
* Port range scanning
* TCP protocol
* UDP protocol
* User-defined timeout time

## Class Diagram
![class diagram](http://s30.postimg.org/h55go01dt/PS_Class_Diagram.png "Class Diagram")

## Technical Description
### MainWindow: Form
This is the main form of the application.

### ScannerManagerSingleton
This class manages port scanning activities. The MainWindow class has a reference to the instance of this singleton class, and calls the ExecuteOneAsync() method after the appropriate button is pushed. The MainWindow class passes a callback delegate that serves as an indicator that one port has been scanned.

### PortScannerBase (abstract)
This is an abstract class that defines the base for PortScanner classes. All specific port scanner classes will inherit from this class. ScannerManagerSingleton refers to all types of PortScanners as PortScannerBase (polymorphism). This class holds the Hostname, Port and Timeout properties that are used by its derived classes for scanning ports. Only one port can be scanned at a time. Between two scans, the ScannerManagerSingleton class must update the hostname and/or port to be scanned.

### TCPPortScanner: PortScannerBase
This is a class that extends PortScannerBase. It implements the method that asynchronously scans one port using the TCP protocol. If a connection is established within the timeout period, the port is considered to be open. The port scanning method takes as a parameter a CancellationToken that is used to request a cancellation. This is implemented by using a Task.WhenAny() method where the first parameter is the port scanning task and the second parameter is a Task.Delay(). The CancellationToken goes as an argument to the Delay(). That way, when cancellation is requested, it acts as if th timeout period had elapsed and port scanning stops, returning false.
**Note:** The TCPPortScanner ensures that the connection that was opened is then closed to avoid performing a Denial-of-service attack. 

### UDPPortScanner: PortScannerBase
This is a class that extends PortScannerBase. It implements the method that asynchronously scans one port using the TCP protocol. If no response is obtained from the server, the class considers it as an open port. If for any reason there is a response, it means that the port is closed. The cancellation mechanism is implemented in the same way as for the TCPPortScanner class above.

### InputChecker (static)
This static class is a library of methods that are used to check whether the input in the MainWindow class is valid or not (hostname, port range, timeout).

### TimeoutListItem
This class is used to build a data source for the timeout period ComboBox in the MainWindow form. It contains a integer array of various timeout periods (in ms) and a static method that is used to build and return a list of TimeoutListItems that will be used to populate the appropriate ComboBox in MainWindow.

## TODO
* SYN port scanning
* Logging to file
* Non-stop loop scanning
