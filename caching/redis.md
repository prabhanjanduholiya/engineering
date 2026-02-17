# Caching 
### Cache aside pattern
* If data not found in cache, first time get data from data source
* Save data in cache
* Next time use cache data
* Disadvantage in it loads infrequent data also.
### Caching Types
* Private Cache
* Shared Cache
  
# Redis
##### Where should i use caching? or Which data needs to be cached?
The data that is frequently used and doesn't change frequently.

##### What is Redis and why it is used? 
Redis is a key-value data store. 

##### Why Redis is fast? 
* Light weight simple architectecure.
* Key- Value Retrival
* In Memory

##### Azure Redis cache tiers
* Basic
* Standard
* Premium (Only premium tiers supports virtual networks)
* Enterprise
* Enterprise Flash - (This tier extends redis data storage to non volatilememory. Which is cheaper than DRAM on VM, It reduces memory cost)

### Azure Redis Evection Policies
Comes into picture when cache reaches memory limit.

##### Volatile Keys- 
Cache keys that have expireation time associated to them are called volatile keys.

##### Eviction Policies
* No eveiction policy
* All keys - lru (Least recently used)
* All keys - fru 
* Volatile keys - lru
* Volatile Keys fru

### Persistance models for Azure redis cache

##### Redis Data Types: 
* Strings
* Lists
* Hashes
* Sets
* Sorted Sets
  ###### How to choose between different redis data types?

##### Redis Keys: 
* Binary Safe
* Having very long/short keys is not good idea
##### Redis CLI

##### Redis Commands
* Set Key Value
* Get Key
* Scan - for getting more/all

## Using Redis in ASP.Net Core

##### Using IDistributedCache
* Simple
* Restricted data types are allowed.
* Package 'Microsoft.Extensions.Caching.StackExchangeRedis'

##### Using IConnectionMultiplexer
* All data types are supported
* * Package 'Microsoft.Extensions.Caching.StackExchangeRedis' or 'StackExchange.Redis'

## Redis as a Primary DB
Redis does more than acting as a cache like 'Database', 'Message Broker'.
Redis offer number of approaches for data persistance. You doesn't loose data if redis restarts.
* [Redis as primary DB](https://www.youtube.com/watch?v=GgyizgXwXAg)
