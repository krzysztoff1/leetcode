# Before allow permsions: chmod +x ./.scripts/cs-new.sh

while [[ "$#" -gt 0 ]]; do
    case $1 in
        -n|--name) name="$2"; shift ;;
        *) echo "Unknown parameter passed: $1"; exit 1 ;;
    esac
    shift
done

if [ -z "$name" ]; then
    echo "Name is required, example: --name my-name"
    exit 1
fi

echo "Creating new csharp leetcode problem with name: $name"

mkdir -p ./csharp/$name
dotnet new console -n $name -o ./csharp/$name

echo "Created new csharp leetcode problem with name: $name"
