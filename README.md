# Utility.BaseClasses
***
This .dll contains base classes that can be easily used in multiple projects. It reduces the need to copy class code into new projects and allows for simpler updates accross all projects that reference these classes.

### Available Classes

#### Error
***
A class that allows you to store and return an HttpStatusCode and a string message. This is very useful when returning responses from API requests where you need to return the status code and a message about why the status code was returned.

#### CustomException
***
Extends the Exception class to give you a HttpStatusCode and Message as well as the base Exception information.

#### HttpRequest.UserAgent
***
The static HttpRequest.UserAgent class is used to correctly format the UserAgent string that is sent in the request header of web service calls. It simplifies the process so all you need to do is call the Get() method.The static HttpRequest.UserAgent class is used to correctly format the UserAgent string that is sent in the request header of web service calls. It simplifies the process so all you need to do is call the Get() method.


