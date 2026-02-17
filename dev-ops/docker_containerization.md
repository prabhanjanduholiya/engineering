# Containerization: 

Containerization is an approach to software development in which an application or service, its dependencies, and its configuration (abstracted as deployment manifest files) are packaged together as a container image. The containerized application can be tested as a unit and deployed as a container image instance to the host operating system (OS). 

Containers also isolate applications from each other on a shared OS. Containerized applications run on top of a container host that in turn runs on the OS (Linux or Windows). Containers therefore have a significantly smaller footprint than virtual machine (VM) images.

Another benefit of containerization is scalability. You can scale out quickly by creating new containers for short-term tasks. 

From an application point of view, instantiating an image (creating a container) is similar to instantiating a process like a service or web app. 

For reliability, however, when you run multiple instances of the same image across multiple host servers, you typically want each container (image instance) to run in a different host server or VM in different fault domains.

### Container image Vs Container:
 
**Container image:**

A package with all the dependencies and information needed to create a container. An image includes all the dependencies (such as frameworks) plus deployment and execution configuration to be used by a container runtime. Usually, an image derives from multiple base images that are layers stacked on top of each other to form the container’s filesystem. An image is immutable once it has been created.

 **Container:**

An instance of a Docker image. A container represents the execution of a single application, process, or service. It consists of the contents of a Docker image, an execution environment, and a standard set of instructions. When scaling a service, you create multiple instances of a container from the same image. Or a batch job can create multiple containers from the same image, passing different parameters to each instance.

**Benefits of containers:** 

Containers offer the benefits of
 
* Isolation
* Portability 
* Agility
* Scalability 
* Control across the whole application lifecycle workflow. 

## Docker 
Docker is an open-source project for automating the deployment of applications as portable, self-sufficient containers that can run on the cloud or on-premises.

**Docker File:** 

A text file that contains instructions for building a Docker image. It’s like a batch script. 
The first line states the base image to begin with and then follow the instructions to install required programs, copy files, and so on, until you get the working environment you need.

**Docker Image Tags: **

A mark or label you can apply to images so that different images or versions of the same image (depending on the version number or the target environment) can be identified.

**Docker Compose:** 

A command-line tool and YAML file format with metadata for defining and running multi-container applications. 
You define a single application based on multiple images with one or more .yml files that can override values depending on the environment. 

After you’ve created the definitions, you can deploy the whole multi-container application with a single command (```docker-compose up```) that creates a container per image on the Docker host.

**Docker Host:**

A Docker host is a physical or virtual server on which the core component of Docker runs, the Docker engine. The Docker engine encapsulates and runs workloads in Docker containers.

Like a hypervisor, the Docker engine provides portions of the host's computing resources to its containers, and it isolates containers from one another.

Unlike a hypervisor, the Docker engine does not run separate guest operating systems for its containers. All containers share the same Docker host kernel. As a consequence, workloads in containers cannot use features that are not supported by the Docker host kernel. For the broadest workload potential, use the most recent version of your distribution.

**Docker Daemon?**

**Volumes:** 

Offer a writable filesystem that the container can use. Since images are read-only but most programs need to write to the filesystem, volumes add a writable layer, on top of the container image, so the programs have access to a writable filesystem. The program doesn’t know it’s accessing a layered filesystem, it’s just the filesystem as usual. Volumes live in the host system and are managed by Docker.

**How to build docker image?** 

The action of building a container image based on the information and context provided by its Dockerfile, plus additional files in the folder where the image is built. You can build images with the following Docker command:

```docker build ```

**What exactly happens when you run command ```docker run hello-world``` ?** 

Command ```docker run hello-world``` means you wanted to create the instance of docker image named as ```hello-world```. 

It means you wanted to start a conatiner for docker image ```hello-world```

To create the instance of docker image, it tries to find the image ```hello-world``` locally from image cache.

If it is not found in image cache locally, 
 - Docker client contacted to docker daemon. 
 - Docker daemon pulls the docker image ```hello-world``` from   docker hub.
 - Docker daemon created the new container from that image.

Else,  

## Containers Repository: 
A collection of related Docker images, labeled with a tag that indicates the image version. 

Some repos contain multiple variants of a specific image, such as an image containing SDKs (heavier), an image containing only runtimes (lighter), etc. Those variants can be marked with tags. 

A single repo can contain platform variants, such as a Linux image and a Windows image.

## Containers Registry: 
A service that provides access to repositories. The default registry for most public images is Docker Hub . 

A registry usually contains repositories from multiple teams. Companies often have private registries to store and manage images they’ve created. Azure Container Registry is another example.

The registry is like a bookshelf where images are stored and available to be pulled for building containers to run services or web apps.

 **Docker Hub:** 

A public registry to upload images and work with them. Docker Hub provides Docker image hosting, public or private registries, build triggers and web hooks, and integration with GitHub and Bitbucket.

**Azure Container Registry:** 

A public resource for working with Docker images and its components in Azure. This provides a registry that’s close to your deployments in Azure and that gives you control over access, making it possible to use your Azure Active Directory groups and permissions.

**When will you use private registries?**

* Your images must not be shared publicly due to confidentiality.
* You want to have minimum network latency between your images and your chosen deployment environment. For example, if your production environment is Azure cloud, you probably want to store your images in Azure Container Registry so that network latency will be minimal. In a similar way, if your production environment is on-premises, you might want to have an on-premises Docker Trusted Registry available within the same local network. 

<img width="494" alt="image" src="https://github.com/prabhanjanduholiya/learn.azure/assets/31764786/41c5d1a8-8b2c-42ad-a86a-7ce549dd4985">
 
## Virtual machines vs Docker containers?

**Virtual Machines-**

Virtual machines include the application, the required libraries or binaries, and a full guest operating system. Full virtualization requires more resources than containerization

For VMs, there are three base layers in the host server, from the bottom-up: infrastructure, Host Operating System and a Hypervisor and on top of all that each VM has its own OS and all necessary libraries.

**Docker containers-**

Containers include the application and all its dependencies. However, they share the OS kernel with other containers, running as isolated processes in user space on the host operating system. (Except in Hyper-V containers, where each container runs inside of a special virtual machine per container.)

For Docker, the host server only has the infrastructure and the OS and on top of that, the container engine, that keeps container isolated but sharing the base OS services.

Containers require far fewer resources (for example, they don’t need a full OS), they’re easy to deploy and they start fast. This allows you to have higher density, meaning that it allows you to run more services on the same hardware unit, thereby reducing costs.

As a side effect of running on the same kernel, you get less isolation than VMs.

The main goal of an image is that it makes the environment (dependencies) the same across different deployments. This means that you can debug it on your machine and then deploy it to another machine with the same environment guaranteed.
