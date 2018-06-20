#! /bin/bash

for f in *.csx; do echo $f; dotnet-script $f; done
