# A Web App created with .NET 5.0
## A Site Management application functions
- Add/remove/edit buildings and the residences in the buildings
- Add/remove/edit Residence owner/user/residents
  - user may be owner or tenant or anyone who is responsible
  - residents may be owner, user or neither
- People can have vehicles (car, van, suv...)
- site/and users have separate invoices
- users can pay their invoices or dues issued by site admin monthly
- admin (manager) can pay, track site or resident invoices and pay them
- admin can send messages to owners and users
- owners and users can send messages to admin

# Database model
![UML class](https://user-images.githubusercontent.com/59605826/164702141-bae70ed3-9474-44ef-a3d2-ec905e2868f8.jpeg)
# Managing user profile
  - Only admin can change personal info, users without "Admin" role may change their contact and login information only.
![image](https://user-images.githubusercontent.com/59605826/164702588-2ea397e1-02cf-49a4-a8a7-ddd09b1ff440.png)
![image](https://user-images.githubusercontent.com/59605826/164702876-42fdc7d5-b0e9-4481-9fc6-7a64cd894e87.png)


# Managing Residences
This menu can only be viewed and used by the user who have "Admin" role.
![image](https://user-images.githubusercontent.com/59605826/164702381-7f29c1a8-2e44-4d66-9917-ec4bee9c4a7f.png)
![image](https://user-images.githubusercontent.com/59605826/164702465-d3c783dd-249b-432f-85fc-ea49ec34b212.png)

# Managing Owner, User and Residents
After entering buildings adn residences, admin may now manage people related to the site and residences.
