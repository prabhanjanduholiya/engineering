# Compute is - 

* Set of services for hosting and running applications.
* Allows uploading of code and running it. 
* Offers various level of control and flexibility

# Various type of cloud services

<img width="716" height="531" alt="image" src="https://github.com/user-attachments/assets/31f2c095-1196-43e3-aed1-d847e4e5525f" />

#### On Premises

#### IaaS (Infra as a service)
* Virtual machines
* networking/venet/subnet

#### PaaS (Platform as a service)
* Like app services, service bus, Azure storage, Cosmos DB

#### SaaS
* Office 365, Outlook etc

### Virtualization: 

### Hypervisor: 

Allows multiple virtual machines to run on a single server by sharing resources and memory.

# Develop Azure Compute Solutions
  ## (1) Implement Iaas Solutions
 **`Power Shell` vs `Cloud Shell`?**

* What is Virtual machine? 
It is a windows/linux server just like physical machine, where you can install and manage softwares.

* Diff between CPU and GPU?
* What is Subscription?
* What are resource groups?
  Resources groups are logical grouping of resources. You can manipulate them at group level like set permissions, delete etc.
* What is VM Agent?

##### ARM (Azure resource manager) Templates:
* What are ARM Templates?
* What is the use/benefits of ARM templates?
Used to achieve desired state configuration. DSC.

##### Containers
* What is Azure container registry/ACR?
* What is Azure container instance/ACI?

## (2) Create Azure App Service Web Apps
     - Create Azure App Service Web Apps
     - Create an Azure App Service Web App
     - Enable diagnostics logging
     - Deploy code to a web app
     - Configure web app settings including SSL, API, and connection strings
     - Implement autoscaling rules, including scheduled autoscaling, and scaling byoperational or system metrics

**App-service**
* What is app-service, How it differs from virtual machines? 
* What are app service plans? 
  App service plan determines the location, feature, cost and compute resource related to your app.
* What are ACU?
* What are deployment slots? (Configure multiple versions of apps like deployment-staging, testing etc)
  Deployment slots are live apps with their host names. App contents and configurations can be swapped between two deployment slots including production.
* What is deployment center?  
* What is web-app console? 
* What is KUDU/KUDU project?

**Web-Jobs**
* What are webjobs?
Webjobs are background tasks that are attached to a webapp.

**Diagnostic Logs**
* How to enable diagnostic logs?
* How to download logs file?
* How to watch log stream in azure?
