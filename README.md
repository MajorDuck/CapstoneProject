# Capstone Project - CNI Subcontract tracking tool   
   
## About:       
This subcontract tracking tool is hosted on Azure and utilizes the Microsoft ASPNetCore-MVC Framework. It is a web application takes subcontract data from a company database and displays each subcontract as a row on a primary index table. There are two tables above the index table which highight subcontracts that are nearing completion, as well as those who have not been updated the longest (potentially neglected). Just above the index table, the user has the option to create a new subcontract with 'Create New' as well as edit, delete, and view details for each existing one.     
     
On the upper right hand of the page, the users email is displayed as a link to account settings. As of now, these features are using ASPNet's built account functions (i.e. managing/changing email).    
    
To the right of aformentioned link is a 'manage' drop down list which serves as the admin tools menu for the site. For users who are not administrators, this menu will not appear nor be accessible. However, users with proper permissions have the ability to do the following:   
* Roles - Add or manage (edit/delete) a role in the 'AspNetRoles' table.   
* UserRoles - Add or delete a User/Role Pair in the 'AspNetUserRoles' table.   
* Statuses - Add or manage a status in the 'DocumentStatus' table, including selection of a highlight color.   
* Doc types - Add or manage a new document type in the 'DocumentType' table (i.e. 'ATP Mod', 'Subcontract').   
* UserLlcs - Add or manage a User/Llcs pair in the 'UserLlc' table (for auto-population of 'Llc' in 'Create New').   
* Llcs - Add or manage a new company Llc to the 'Llc' table.    
  
## Access:  
* Site: https://cnicapstoneproject.azurewebsites.net/   
* Test account (non-admin, some linked Llcs):    
  * Email - group11dummy @ gmail.com
  * Password - Capdummy123!   
    
## Credits:    
* Group 11: An Nguyen, Aiden Witt, Brandon Michaud ,Camron Benefield & Chanon Cserepy        
* Sponsor: Chickasaw Nation Industries, Inc. 2600 John Saxon Blvd, Norman, OK 73071    
* Advisors: Mr. Archer, Mr. Huebsch & Mr. Roland, Esq.   


![Wire Frame for Website](https://github.com/MajorDuck/CapstoneProject/blob/master/SiteWireframe.pdf?raw=true)

