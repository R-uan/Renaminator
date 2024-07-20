package main

import (
	"fmt"
	"os"
	"path/filepath"
	"strings"
)

func main() {
	dir, err := os.Getwd();
	if(err != nil) { panic("Could not get target directory") }

	base := filepath.Base(dir);
	commonName := strings.Join(strings.Split(strings.ToLower(base), " "), "-");

	files, err := os.ReadDir(dir);
	if(err != nil) { panic("Could not get read files from directory") }

	for index, file := range files {
		if !file.IsDir() {
			check := check_duplicate(file, commonName);
			if(check) {
				fileName := file.Name();
				ext := filepath.Ext(fileName);
				newName := fmt.Sprintf("#%s[%d]%s", commonName, index, ext);
				os.Rename(fileName, newName);
			}
		}
	}
}

func check_duplicate(file os.DirEntry, commonName string) (bool) {
	fileName := file.Name();
	check := strings.HasPrefix(fileName, commonName);
	return !check;
}