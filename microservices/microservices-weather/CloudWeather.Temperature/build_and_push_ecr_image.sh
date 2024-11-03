#!/bin/bash
set -e

RegistryName="638764673937.dkr.ecr.eu-west-2.amazonaws.com/cloud-weather-temperature"
ImageTag="${RegistryName}:latest"

aws ecr get-login-password --profile weather-ecr-agent --region eu-west-2 | docker login --username AWS --password-stdin $RegistryName
docker build --quiet -t $ImageTag .
docker push --quiet $ImageTag
docker rmi $ImageTag