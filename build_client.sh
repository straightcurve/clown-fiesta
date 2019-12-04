#!/bin/bash
build_platform="$1"
project_path="$(pwd)/client"
build_path="${project_path}/build"
mkdir $build_path

if [ -z $build_platform ]
then
    for platform in "win_x86" "win_x64" "linux"
    do
        mkdir "${build_path}/${platform}"
    done

    unity -batchmode -quit -projectPath $project_path -executeMethod "Automation.Builders.Build_win"
    unity -batchmode -quit -projectPath $project_path -executeMethod "Automation.Builders.Build_linux"
else
    if [ $build_platform = "win" ]
    then
        for arch in "x86" "x64"
        do
            mkdir "${build_path}/win_${arch}"
        done
        unity -batchmode -quit -projectPath $project_path -executeMethod "Automation.Builders.Bui
ld_win"
    else
        mkdir "${build_path}/linux"
        
        unity -batchmode -quit -projectPath $project_path -executeMethod "Automation.Builders.Build_linux"
    fi
fi