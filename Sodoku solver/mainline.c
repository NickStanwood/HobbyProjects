/*
 *	Author: 	Nick Stanwood
 *
 ***********************************************************************************/
 
 #include <stdio.h>
 #include <stdlib.h>
 
 #define SIZE 9
 
 struct square{
 	int val;			//value read from file
 	int poss[SIZE];		//array of possible values
 };
 
 struct square sodoku[SIZE][SIZE] = [0];
 
 int main(void)
 {
 	
	int row,col;
	 
	for(row = 0 ; row < SIZE ; row++){
		for(col = 0 ; col < SIZE ; col++){
			check_adj(row,col,sodoku[row][col].poss)
		}
	}
 }
 
 void init_sod(struct square sodoku[SIZE][])
 {
 	FILE *sod_F = fopen("Sodoku_in.txt","r");
 	int row,col,pos_val;
 	
 	/* load sodoku into sodoku matrix */
 	for(row = 0 ; row < SIZE ; row++){
 		for(col = 0 ; col < SIZE ; col++){
 			fscanf(sod_F , "%d" , &sodoku[i][j].val);
 			/* if the value is not given, set possible values*/
 			if(sodoku[row][col].in == 0){
 				for(pos_val = 0 ; pos_val < SIZE ; pos_val++){
 					sodoku[i][j].poss[pos_val] = pos_val + 1;
				 }
			}
			else{	/* value was given */
				for(pos_val = 0 ; pos_val < SIZE ; pos_val++){
 					sodoku[row][col].poss[pos_val] = 0;
				 }
			}
		}
 
 }
 
 
 
 
