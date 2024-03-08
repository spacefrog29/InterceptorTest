# InterceptorTest

A test application to work with EF Interceptors. 

This project contains a User Model and an Audit Model which is inherted by the User to provide created and modified dates.

When creating a new User the interceptor captures the EF Save routine to add either Added or Modified data to the changing User item.
