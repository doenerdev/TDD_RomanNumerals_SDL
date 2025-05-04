#!/bin/bash

# checkout the next commit
checkout_next() {
    git log --reverse --pretty=%H main | grep -A 1 $(git rev-parse HEAD) | tail -n1 | xargs git checkout
}

# checkout the previous commit
checkout_previous() {
    git checkout $(git rev-parse HEAD)~1
}

if [ "$1" == "next" ]; then
    checkout_next
elif [ "$1" == "prev" ]; then
    checkout_previous
else
    echo "Usage: $0 {next|prev}"
    exit 1
fi