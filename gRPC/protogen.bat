protoc -I . --csharp_out=../Assets/Scripts --grpc_out=../Assets/Scripts --plugin=protoc-gen-grpc="tools\tools\windows_x64\grpc_csharp_plugin.exe" poc3-proto.proto