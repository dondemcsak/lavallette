# Lavallette
## Cloud Maturity Analysis Tool
This project is all about taking the guess work out of determining an application's cloud maturity level, thru the use of executable tests.  The [Twelve-Factor App](http://12factor.net/) does a great job at describing a methodology for building software as a service apps.  Some of those factors are based on the overall development methodology, and some as based on the architecture of the application.  The motivation for Lavallette is to quantify what we can as User Stories, and convert those to static code analysis tests, where possible.  The static code analysis test execution should be able to be inserted into the Continuous Delivery pipeline, to ensure that non-Cloud Native code is not accidentally leaked into the code base.  The tests can also be used on an existing code base to determine it's Cloud Maturity.

## Cloud Native Maturity Model

### Cloud Native
* Micro-service Architecture and Principles
* API first design

### Cloud Resilient
* Designed for failure
* Apps are unaffected by dependent service failures
* Proactive testing for failures
* Metrics and monitoring built in
* Cloud agnostic runtime implementation

### Cloud Friendly
* Twelve-Factor Apps
* Horizontally scalable
* Leverage platform for High Availability

### Cloud Ready
* No file system requirements or uses S3 application
* Self contained application
* Platform managed ports and addressing
* Consume off platform services using platform semantics
* Network connection resiliency
