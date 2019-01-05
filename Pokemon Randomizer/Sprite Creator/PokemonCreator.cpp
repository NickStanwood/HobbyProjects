/*================================================================================*
 *TITLE:  pokemon_creator.c                                                       *
 *PURPOSE: To create randomized pokemon from the head, body and tail of various   *
 *       pokemon. it also uses the color pallete of a specific pokemon            *
 *GLOBALS:        *
 *AUTHOR: Nick Stanwood                                                           *
 *CREATED: may 24, 2017                                                           *
 *REVISION:
 *===============================================================================*/
#include <bitset>
#include <fstream>
#include <iostream>
#include <sstream>
#include <string>
//#include <png.h>
#include "PokemonCreator.hpp"

using namespace std;

/*================================================================================*
 *
 *
 * ===============================================================================*/
int main(void){
	pokemon Mother;
	pokemon Father;
	
	
	int PokeNum = 0;
	char Discard = 0;	
	bool MomData = false;
	bool DadData = false;
	
	ifstream fin("Data/pokemon.txt");
	
	cout << "Enter the mother's pokedex number\n";
	cin >> Mother.Pokedex;
	cout << "Enter the father's pokedex number\n";
	cin >> Father.Pokedex;
	
	/* search through pokemon.txt until the mothers pokedex number is found */
	while(!MomData){
		while(Discard != '['){
			fin >> Discard;	
		}
		fin >> PokeNum >> Discard;
		cout << "index = " << PokeNum << "\n";
		cout << "----------------------------------------------------------------\n";
		
		if(PokeNum == Mother.Pokedex){
			Mother.SetData(fin);
			MomData = true;
			cout << "Mother Data Found\n";	 
			
			if(Father.Pokedex == Mother.Pokedex){
				Father = Mother;
				DadData = true;
			}
		}
	}
	
	fin.seekg(0, fin.beg);		//reset the position in pokemon.txt
	
	/* search through pokemon.txt until the mothers pokedex number is found */
	while(!DadData){
		while(Discard != '['){
			fin >> Discard;	
		}
		fin >> PokeNum >> Discard;
		cout << "index = " << PokeNum << "\n";
		cout << "----------------------------------------------------------------\n";
		
		if(PokeNum == Father.Pokedex){
			Father.SetData(fin);
			DadData = true; 
			cout << "Father Data Found\n";
		}
	}
	
	
	
	return 0;
}


////////////////////////////////// pokemon methods /////////////////////////////////

/*================================================================================*
 * Sets all the variables for a pokemon
 * ===============================================================================*/
void pokemon::SetData(ifstream& fin)
{
	string FileVar;
	string FileStr;
	stringstream FileStream;
	char delimeter  = '=';
	
	int PokeVar;
	int PokeData[16];
	
	getline(fin , FileStr);			//get rid of endl
	
	while(1){
		getline(fin , FileStr);
		FileStream.str(FileStr);
		FileStream.seekp(0 , FileStream.end);
		FileStream << ",";
		FileStream.seekp(0 , FileStream.beg);
		
		getline(FileStream , FileVar , delimeter);
		if(FileVar[0] == '[')
			break;
		PokeVar = CheckFileVar(FileVar);		
		
		switch(PokeVar){
			case PRIMARYCOLOR:
				cout << "PRIMARY COLOR\n";
				for(int i = 0 ; i < 4 ; i++){
					PrimaryColor[i].rgb = GetData(FileStream , HEX);
					PrimaryColor[i].hue = GetData(FileStream , DECIMAL);
					PrimaryColor[i].sat = GetData(FileStream , DECIMAL);
					PrimaryColor[i].val = GetData(FileStream , DECIMAL);	
				}
				break;
			case SECONDARYCOLOR:
				cout << "SECONDARY COLOR\n";
				for(int i = 0 ; i < 4 ; i++){
					SecondaryColor[i].rgb = GetData(FileStream , HEX);
					SecondaryColor[i].hue = GetData(FileStream , DECIMAL);
					SecondaryColor[i].sat = GetData(FileStream , DECIMAL);
					SecondaryColor[i].val = GetData(FileStream , DECIMAL);
				}
				
				break;
			case TERTIARYCOLOR:
				cout << "TERTIARY COLOR\n";
				for(int i = 0 ; i < 4 ; i++){
					TertiaryColor[i].rgb = GetData(FileStream , HEX);
					TertiaryColor[i].hue = GetData(FileStream , DECIMAL);
					TertiaryColor[i].sat = GetData(FileStream , DECIMAL);
					TertiaryColor[i].val = GetData(FileStream , DECIMAL);	
				}
				break;
			case EYECOLOR:
				cout << "EYE COLOR\n";
				break;
			case MOUTHCOLOR:
				cout << "MOUTH COLOR\n";
				break;
			case SHADINGCOLOR:
				cout << "SHADING COLOR\n";
				for(int i = 0 ; i < 3 ; i++){
					ShadingColor[i].rgb = GetData(FileStream , HEX);
					ShadingColor[i].hue = GetData(FileStream , DECIMAL);
					ShadingColor[i].sat = GetData(FileStream , DECIMAL);
					ShadingColor[i].val = GetData(FileStream , DECIMAL);
				}
				break;
			case BODY:
				cout << "BODY\n";
				Body.headx = GetData(FileStream , DECIMAL);
				Body.heady = GetData(FileStream , DECIMAL);
				Body.tailx = GetData(FileStream , DECIMAL);
				Body.taily = GetData(FileStream , DECIMAL);
				break;
			case HEAD:
				cout << "HEAD\n";
				Head.pixelx = GetData(FileStream , DECIMAL);
				Head.pixely = GetData(FileStream , DECIMAL);
				break;
			case TAIL:
				cout << "TAIL\n";
				Tail.pixelx = GetData(FileStream , DECIMAL);
				Tail.pixely = GetData(FileStream , DECIMAL);
				break;
			case BODYBACK:
				cout << "BODYBACK\n";
				BodyBack.headx = GetData(FileStream , DECIMAL);
				BodyBack.heady = GetData(FileStream , DECIMAL);
				BodyBack.tailx = GetData(FileStream , DECIMAL);
				BodyBack.taily = GetData(FileStream , DECIMAL);
				break;
			case HEADBACK:
				cout << "HEADBACK\n";
				HeadBack.pixelx = GetData(FileStream , DECIMAL);
				HeadBack.pixely = GetData(FileStream , DECIMAL);
				break;
			case TAILBACK:
				cout << "TAILBACK\n";
				TailBack.pixelx = GetData(FileStream , DECIMAL);
				TailBack.pixely = GetData(FileStream , DECIMAL);
				break;
			default:
				cout << "Unimportant pokevariable\n";
				getchar();
				break;
		}
	}	
	
	PrintStats();
	return;	
}

/*================================================================================*
 * gets the data for a pokemon from pokemon.txt
 * ===============================================================================*/
int pokemon::GetData(stringstream& FileStream , int base)
{
	string FileData;
	int RtnVal;
	
	if(getline(FileStream , FileData , ',') && !FileStream.eof()){
		RtnVal = stoi(FileData , 0 , base);
	}
		
	else{
		RtnVal = 0;
		FileStream.clear();
		
	}
		
	
	return RtnVal;
}


/*================================================================================*
 * prints out all the stats of a pokemon. 
 * ===============================================================================*/
void pokemon::PrintStats(void){
	
	cout << "Pokemon: " << Pokedex << "\n";
	cout << "--------------------------------------------------------------------\n";
	cout << "\nPrimaryColor: \n";
	for(int i = 0 ; i < 4 ; i++){
		cout << "0x" << hex << PrimaryColor[i].rgb << " , ";
		cout << dec << PrimaryColor[i].hue << " , ";
		cout << dec << PrimaryColor[i].sat << " , ";
		cout << dec << PrimaryColor[i].val << " \n";
	}
	
	cout << "\nSecondaryColor: \n";
	for(int i = 0 ; i < 4 ; i++){
		cout << "0x" << hex << SecondaryColor[i].rgb << " , ";
		cout << dec << SecondaryColor[i].hue << " , ";
		cout << dec << SecondaryColor[i].sat << " , ";
		cout << dec << SecondaryColor[i].val << " \n";
	}
	
	cout << "\nTertiaryColor: \n";
	for(int i = 0 ; i < 4 ; i++){
		cout << "0x" << hex << TertiaryColor[i].rgb << " , ";
		cout << dec << TertiaryColor[i].hue << " , ";
		cout << dec << TertiaryColor[i].sat << " , ";
		cout << dec << TertiaryColor[i].val << " \n";
	}
	
	cout << "\nShadingColor: \n";
	for(int i = 0 ; i < 3 ; i++){
		cout << "0x" << hex << ShadingColor[i].rgb << " , ";
		cout << dec << ShadingColor[i].hue << " , ";
		cout << dec << ShadingColor[i].sat << " , ";
		cout << dec << ShadingColor[i].val << " \n";
	}
	cout << "\nBody: \n";
	cout <<  Body.headx << ",  ";
	cout <<  Body.heady << " , ";
	cout <<  Body.tailx << " , ";
	cout <<  Body.taily << " \n";

	cout << "\nHead: \n";
	cout << Head.pixelx << " , ";
	cout << Head.pixely << " \n";
	
	cout << "\nTail: \n";
	cout << Tail.pixelx << " , ";
	cout << Tail.pixely << " \n";

	cout << "\nBodyBack: \n";
	cout <<  BodyBack.headx << ",  ";
	cout <<  BodyBack.heady << " , ";
	cout <<  BodyBack.tailx << " , ";
	cout <<  BodyBack.taily << " \n";
	
	cout << "\nHeadBack: \n";
	cout << HeadBack.pixelx << " , ";
	cout << HeadBack.pixely << " \n";
	
	cout << "\nTailBack: \n";
	cout << TailBack.pixelx << " , ";
	cout << TailBack.pixely << " \n";
	
	getchar();
	getchar();
	return;
}

//////////////////////////////    Global Functions    //////////////////////////////

/*================================================================================*
 * compares the retrieved variable from pokemon.txt to a list of important 
  * varibles
 * ===============================================================================*/
int CheckFileVar(string& FileVar)
{
	int PokeVar = DISCARDSTAT;
	
	if(!FileVar.compare("PrimaryColor"))
		PokeVar = PRIMARYCOLOR;	
		
	else if(!FileVar.compare("SecondaryColor")){
		PokeVar = SECONDARYCOLOR;	
	}	
	else if(!FileVar.compare("TertiaryColor"))
		PokeVar = TERTIARYCOLOR;
		
	else if(!FileVar.compare("EyeColor"))
		PokeVar = EYECOLOR;
		
	else if(!FileVar.compare("MouthColor"))
		PokeVar = MOUTHCOLOR;
		
	else if(!FileVar.compare("ShadingColor"))
		PokeVar = SHADINGCOLOR;
		
	else if(!FileVar.compare("Body"))
		PokeVar = BODY;
		
	else if(!FileVar.compare("Head"))
		PokeVar = HEAD;
		
	else if(!FileVar.compare("BodyBack"))
		PokeVar = BODYBACK;
		
	else if(!FileVar.compare("HeadBack"))
		PokeVar = HEADBACK;
		
	else if(!FileVar.compare("TailBack"))
		PokeVar = TAILBACK;
	
	return PokeVar;
}











