/*================================================================================*
 * TITLE:	PokemonCreator.hpp													  *
 * PURPOSE:		*
 * GLOBALS:		*
 * AUTHOR:	Nick Stanwood														  *
 * CREATED:	*
 * REVISION:	*
 * ===============================================================================*/
#ifndef _POKEMONCREATOR_H_
#define _POKEMONCREATOR_H_

#include <iostream>
#include <fstream>
#include <cstring>
//#include <png.h>

using namespace std;

enum pokemonvariables {	
	PRIMARYCOLOR,
	SECONDARYCOLOR,
	TERTIARYCOLOR,
	EYECOLOR,
	MOUTHCOLOR,
	SHADINGCOLOR,
	BODY,
	HEAD,
	TAIL,
	BODYBACK,
	HEADBACK,
	TAILBACK,
	DISCARDSTAT
};

enum numbase {
	BINARY 	= 2 ,
	DECIMAL = 10,
	HEX		= 16,
	
};

/*================================================================================*
 *
 *
 * ===============================================================================*/
class color{
public:
    int rgb;
    int hue;
    int sat;
    int val;
    color(void):
    	rgb(0) , hue(0) , sat(0) , val(0) 
	{}
};

/*================================================================================*
 *
 *
 * ===============================================================================*/
class body{
public:
    int headx;
    int heady;
    int tailx;
    int taily;
    body(void){
    	headx = 0;
		heady = 0;
		tailx = 0;
		taily = 0;	
	}
    	
};

/*================================================================================*
 *
 *
 * ===============================================================================*/
class appendage{
public:
    int pixelx;
    int pixely;
    appendage(void):
    	pixelx(0) , pixely(0) {}
};

/*================================================================================*
*
*
* ===============================================================================*/
class pokepng {
public:
//	GetPng(int pokedex, string BodyPart);
private:
	int width;
	int height;
	int pixelx1;
	int pixely1;
	int pixelx2;
	int pixely2;

};

/*================================================================================*
 *
 *
 * ===============================================================================*/
class pokemon{
public:
	int Pokedex;
	void SetData(ifstream&);
	int GetData(stringstream& FileVals , int base);
	void PrintStats(void);
	
private:	
    color PrimaryColor[4];
    color SecondaryColor[4];
    color TertiaryColor[4];
    color Eyecolor[3];
    color MouthColor[2];
    color ShadingColor[3];

    body Body;
    body BodyBack;

    appendage Head;
    appendage HeadBack;
    appendage Tail;
    appendage TailBack;
    
    pokepng BodyPic;
    pokepng Headpic;
	pokepng TailPic;
    pokepng BodyBackPic;
	pokepng HeadBackpic;
	pokepng TailBackpic;
};

int CheckFileVar(string& FileVar);

#endif



