# Azure Blob Storage

Azure Blob storage is Microsoft's object storage solution for the cloud. Blob storage is optimized for storing massive amounts of unstructured data. Unstructured data is data that doesn't adhere to a particular data model or definition, such as text or binary data.

Objects in Blob storage are accessible via the Azure Storage REST API, Azure PowerShell, Azure CLI, or an Azure Storage client library.

Blob storage is designed for:
* Serving images or documents directly to a browser.
* Storing files for distributed access.
* Streaming video and audio.
* Writing to log files.
* Storing data for backup and restore, disaster recovery, and archiving.
* Storing data for analysis by an on-premises or Azure-hosted service.

## Storage accounts

An Azure Storage account is the top-level container for all of your Azure Blob storage. The storage account provides a unique namespace for your Azure Storage data that is accessible from anywhere in the world over HTTP or HTTPS.

### Types of storage accounts
Azure Storage offers two performance levels of storage accounts, standard and premium. Each performance level supports different features and has its own pricing model.

###### *Standard: 
This is the standard general-purpose v2 account and is recommended for most scenarios using Azure Storage.
###### *Premium: 
Premium accounts offer higher performance by using solid-state drives. 
If you create a premium account you can choose between three account types- 
* Block blobs 
* Page blobs, or 
* File shares.

## Access tiers for block blob data

The available access tiers are:

###### *The Hot access tier- 
Which is optimized for frequent access of objects in the storage account. The Hot tier has the highest storage costs, but the lowest access costs. New storage accounts are created in the hot tier by default.

###### *The Cool access tier- 
Which is optimized for storing large amounts of data that is infrequently accessed and stored for a minimum of 30 days. The Cool tier has lower storage costs and higher access costs compared to the Hot tier.

###### *The Cold access tier- 
Which is optimized for storing data that is infrequently accessed and stored for a minimum of 90 days. The cold tier has lower storage costs and higher access costs compared to the cool tier.

###### *The Archive tier- 
Which is available only for individual block blobs. The archive tier is optimized for data that can tolerate several hours of retrieval latency and remains in the Archive tier for a minimum 180 days. The archive tier is the most cost-effective option for storing data, but accessing that data is more expensive than accessing data in the hot or cool tiers.

## Azure Blob storage resource types
###### *Storage Account - 
A storage account provides a unique namespace in Azure for your data. Eg. http://mystorageaccount.blob.core.windows.net
###### *A container in Blob storage - 
* A container organizes a set of blobs, similar to a directory in a file system. A storage account can include an unlimited number of containers, and a container can store an unlimited number of blobs.
* A container name must be a valid DNS name, as it forms part of the unique URI (Uniform resource identifier) used to address the container or its blobs. 
###### *A Blob in a container
Azure Storage supports three types of blobs:

* Block blobs store text and binary data. Block blobs are made up of blocks of data that can be managed individually. Block blobs can store up to about 190.7 TiB.
* Append blobs are made up of blocks like block blobs, but are optimized for append operations. Append blobs are ideal for scenarios such as logging data from virtual machines.
* Page blobs store random access files up to 8 TB in size. Page blobs store virtual hard drive (VHD) files and serve as disks for Azure virtual machines.

## Azure Storage security features

Azure Storage automatically encrypts your data when persisting it to the cloud. Encryption protects your data and helps you meet your organizational security and compliance commitments. Data in Azure Storage is encrypted and decrypted transparently using 256-bit Advanced Encryption Standard (AES) encryption. However, the Azure Storage client libraries for Blob Storage and Queue Storage also provide client-side encryption for customers who need to encrypt data on the client.

Azure Storage encryption is enabled for all storage accounts and can't be disabled. Because your data is secured by default, you don't need to modify your code or applications to take advantage of Azure Storage encryption.

Data in a storage account is encrypted regardless of performance tier, access tier, or deployment model.

##### Encryption key management

Data in a new storage account is encrypted with Microsoft-managed keys by default. You can continue to rely on Microsoft-managed keys for the encryption of your data, or you can manage encryption with your own keys. If you choose to manage encryption with your own keys, you have two options. You can use either type of key management, or both:

* You can specify a customer-managed key to use for encrypting and decrypting data in Blob Storage and in Azure Files. Customer-managed keys must be stored in Azure Key Vault or Azure Key Vault Managed Hardware Security Model (HSM).

* You can specify a customer-provided key on Blob Storage operations. A client can include an encryption key on a read/write request for granular control over how blob data is encrypted and decrypted.

##### Client-side encryption
The Azure Blob Storage client libraries for .NET, Java, and Python support encrypting data within client applications before uploading to Azure Storage, and decrypting data while downloading to the client. The Queue Storage client libraries for .NET and Python also support client-side encryption.
The Blob Storage and Queue Storage client libraries uses AES in order to encrypt user data. There are two versions of client-side encryption available in the client libraries:

* Version 2 uses Galois/Counter Mode (GCM) mode with AES. The Blob Storage and Queue Storage SDKs support client-side encryption with v2.
* Version 1 uses Cipher Block Chaining (CBC) mode with AES. The Blob Storage, Queue Storage, and Table Storage SDKs support client-side encryption with v1.

## Manage the Azure Blob storage lifecycle
Data sets have unique lifecycles. Early in the lifecycle, people access some data often. But the need for access drops drastically as the data ages. Some data stays idle in the cloud and is rarely accessed once stored.

Azure storage offers different access tiers, allowing you to store blob object data in the most cost-effective manner.
Azure Blob Storage lifecycle management offers a rule-based policy that you can use to transition blob data to the appropriate access tiers or to expire data at the end of the data lifecycle.

With the lifecycle management policy, you can:

* Transition blobs from cool to hot immediately when accessed, to optimize for performance.
* Transition current versions of a blob, previous versions of a blob, or blob snapshots to a cooler storage tier if these objects aren't accessed or modified for a period of time, to optimize for cost.
* Delete current versions of a blob, previous versions of a blob, or blob snapshots at the end of their lifecycles.
* Apply rules to an entire storage account, to select containers, or to a subset of blobs using name prefixes or blob index tags as filters.

#### Lifecycle Policies
- A lifecycle management policy is a collection of rules in a JSON document. Each rule definition within a policy includes a filter set and an action set. 
- The filter set limits rule actions to a certain set of objects within a container or objects names.


Policy- 
* A policy is a collection of rules:
* Each rule within the policy has several parameters: name,enabled,type,definition
* Each rule definition includes a filter set and an action set.
* The filter set limits rule actions to a certain set of objects within a container or objects names. The action set applies the tier or delete actions to the filtered set of objects.

#### Rule actions
Actions are applied to the filtered blobs when the run condition is met.

Lifecycle management supports tiering and deletion of blobs and deletion of blob snapshots. Define at least one action for each rule on blobs or blob snapshots.
tierToCool, tierToCold, enableAutoTierToHotFromCool, tierToArchive, delete

Run conditions:
run conditions are based on age. Base blobs use the last modified time to track age, and blob snapshots use the snapshot creation time to track age.
daysAfterModificationGreaterThan
daysAfterCreationGreaterThan
daysAfterLastAccessTimeGreaterThan
daysAfterLastTierChangeGreaterThan

Rule filters

blobTypes
prefixMatch
blobIndexMatch

```
{
  "rules": [
    {
      "enabled": true,
      "name": "sample-rule",
      "type": "Lifecycle",
      "definition": {
        "actions": {
          "version": {
            "delete": {
              "daysAfterCreationGreaterThan": 90
            }
          },
          "baseBlob": {
            "tierToCool": {
              "daysAfterModificationGreaterThan": 30
            },
            "tierToArchive": {
              "daysAfterModificationGreaterThan": 90,
              "daysAfterLastTierChangeGreaterThan": 7
            },
            "delete": {
              "daysAfterModificationGreaterThan": 2555
            }
          }
        },
        "filters": {
          "blobTypes": [
            "blockBlob"
          ],
          "prefixMatch": [
            "sample-container/blob1"
          ]
        }
      }
    }
  ]
}
```

### Implement Blob storage lifecycle policies
You can add, edit, or remove a policy by using any of the following methods:

##### *Azure portal:
* In the Azure portal, navigate to your storage account.
* Under Data management, select Lifecycle Management to view or change lifecycle management policies.
* Select the Code View tab. On this tab, you can define a lifecycle management policy in JSON.
##### *Azure PowerShell
##### *Azure CLI
To add a lifecycle management policy with Azure CLI, write the policy to a JSON file, then call the az storage account management-policy create command to create the policy. A lifecycle management policy must be read or written in full. Partial updates aren't supported.
```
az storage account management-policy create --account-name <storage-account> --policy @policy.json --resource-group <resource-group>
```
##### *REST APIs

## Rehydrate blob data from the archive tier
While a blob is in the archive access tier, it's considered to be offline and can't be read or modified. In order to read or modify data in an archived blob, you must first rehydrate the blob to an online tier, either the hot or cool tier. There are two options for rehydrating a blob that is stored in the archive tier:
* Copy an archived blob to an online tier
* Change a blob's access tier to an online tier:

----------------------------------------------------------------------------------------------------------------------
* Storage accounts doesn't costs much if we are not storing data in it. It costs around 2cents/month for 1 GB approximately.
Managed storage accounts
Unmanaged storage accounts

##### What are options available in azure storage?
* Container
* Tables
* Queues 
* Files Share


##### What is Replication in azure storage accounts? 
This option is used to mentain the redundancy of files in same or other data center, location or zone. These options vary on the basis of selected location of storage account.

###### (1) Locally redundant storage (LRS) - 
It mentains 3 copies behind the scene for every file stored in storage within same location and within same data center.

###### (2) Geo redundant storage (GRS)
* It mentains 6 copies behind the scene for every file stored in storage. 3 copies are stored within same location and within same data center and rest 3 copies are stored in another data center.
* This for higher availability of files, if there is any problem in any of data center

###### (3) Read-access geo-redundant-storage (RA-GRS)
* It mentains 6 copies behind the scene for every file stored in storage. 3 copies are stored within same location and within same data center and rest 3 copies are stored in another data center.
* This for higher availability of files, if there is any problem in any of data center
* It provides read access urls for accessing files. Means seperate urls for read and write access of files.

##### Network connectivity of storage accounts
* Public endpoint (All networks)
* Public endpoint (Selected networks)
* Private Endpoint

##### What is access tier in storage accounts?
##### What is SAS (Shared access signature)?
##### What is data lake? 

# Azure Blob Storage
Blob storage is optimized for massive amount of unstructured data. Blob storage is designed for 
* Serving images and documents from server
* Storing files for distributed access
* Streaming video and audio
* Writing to log files

### Access Blob storage
Users and client applications can access objects via Rest Api or azure storage client library.

### Type of Blob Storage Accounts
Azure storage offers two performance levels of storage accounts
* Standard - Genrel purpose V2 account recommanded for most scenerios 
* Premium  
  - Block Blob
  - Page Blob

### Access Tiers for Block Blob Data

##### (1) Hot Access Tiers
* Optimized for frequent access of objects in storage account
* Highest storage cost and lowest access cost

##### (2) Cold Access Tiers
* Optimized for large amount of data that is infrequently accessed.
* Lower storage cost and higher access cost

##### (3) Achieve Access Tiers
* Optimized for data that can tolerate several hours of retrieval latency.

 


### Type of Blobs
##### * Block Blobs
Designed for storing text and binary data.

##### * Append Blobs
Similar to block blobs but optimized for append operations.

##### * Page Blobs
Designed for storing random access files up to 8TB in size.
 
