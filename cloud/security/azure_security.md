# Microsoft identity platform
###### components
* OAuth 2.0 and OpenID Connect standard-compliant authentication service
* Open-source libraries: Microsoft Authentication Libraries (MSAL)
* Application management portal
* Application configuration API and PowerShell


# Control Access to Azure

### Role Based Access Control (RBAC)
* Default way of granting access to azure resources
* Handle authorization across all resources

##### Components of RBAC Assignment
* Scope - scope could be at subscription level, resource group level or resource level 
* Azure AD object - It is target like user, user group or application
* Role - Collection of resource provider action

##### RBAC vs Azure AD
* RBAC handle authorization while Azure AD provide authentication. 

##### Azure Resource Manager Terminology
* Azure active directory tenant
* Subscription
* Resource Group
* Resource Provider
* Resource

##### Azure RBAC Roles for development
* Owner - Can do anything within scope like manage resource groups, resources, users.
* Contributor - It is a default role, lets user read/update/delete resources but doesn't have access to manage users.
* Reader - Read only access within scope such as configuration.
* User access administrator role 
      - Used for managing user access, Can't change resources. View only access to resource providers.
      - When possible choose this role over Owner role because owner role is combination of all.

###### Custom RBAC roles:

##### Azure active directory roles for development
* Application Developer - Create/Manage app registrations
* Guest Inviter - Let's you to invite new users from other organization.


 
# Control User Access to Apps
#### Register application to azure active directory
* To authenticate application/users using and existing identity provider
* We can focus on authorization
* In practice an application object and service principle are created in azure AD

##### How to register app app in AD
* Go to azure AD
* Click App registration
* New Registration

##### Choose supported account types/tenancy
* Single Tenant (Just one organization)
* Multi Tenant (Multiple Organizations)
* Multi Tenant + Personal Microsoft account  

# Control App Access to Data
### Shared Access Signature 
* Grant access for specific time frame
* Specify permissions like read/write
* Policies can be created
* Specific IP addresses can be specified 

### Valet key pattern
### Azure Key Vault
A centralized and secure location to store your keys and secrets.

###### Key vault features
* Auditing
* Versioning
* Key Management
* Access Control

###### Key vault access management 
Managed with access policies. Apply to entire key vault

###### Key Vault access policies 

###### Managed Identity for azure resources
 
