//prints genetic data to .csv file
//original code by smkplus
//modified by tabacwoman november 2021


using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;

public class BlybGenetics : MonoBehaviour
{

GameObject[] blybs;

private List<string[]> rowData = new List<string[]>();
    int itCount;
    
    float time;
    float totalTime;

    public int maxSampleSize;
    int sampleSize;
    public float sampleRate;
    
   

    int sampler;
    public List <int> generation;
    public List <float> intron1;
    public List <float> intron2;
    public List <float> intron3;
    public List <float> intron4;

    public List <float> moveAllele1;
    public List <float> moveAllele2;
    public List <float> redAllele1;
    public List <float> redAllele2;
    public List <float> greenAllele1;
    public List <float> greenAllele2;
    public List <float> blueAllele1;
    public List <float> blueAllele2;
    public List <float> LifeSpan;
     public List <float> lookDistance;
    public List <float> turnTorqueAllele1;
    public List <float> turnTorqueAllele2;
    public List <float> turnDice;
    public List <float> energyToReproduce;
    public List <float> conjAge;

    bool refCheck = false;
    bool brainCheck = false;
    int sampleGroup;
    

    // Start is called before the first frame update
    void Start()
    {
        itCount = 0;
        sampleGroup = 0;
    }

    // Update is called once per frame
    void Update()
    {

        
        totalTime = Mathf.Round(Time.time);
        time += Time.deltaTime;
        
        if (time >= sampleRate){
               refCheck = false;
               brainCheck = false;
                blybs  = GameObject.FindGameObjectsWithTag("Predator2");
                
                if(blybs.Length <= 0){return;}
                if(blybs.Length >= 1){
                    if(blybs.Length < maxSampleSize){sampleSize = blybs.Length;}
                    if(blybs.Length >= maxSampleSize){sampleSize = maxSampleSize;}
            
                refCheck = blybs[0].TryGetComponent(out BlybControls blybControls);
                brainCheck = blybs[0].TryGetComponent(out BrainBlybControls brainBlybControls);
                



                        if (refCheck == true)
                        {
                            for (int i = 0; i < sampleSize; i++)
                            {   
                    
                    
                                sampler = UnityEngine.Random.Range(0,sampleSize);
                                BlybControls  sampledBlyb = blybs[sampler].GetComponent<BlybControls>();

                                intron1.Add(sampledBlyb.intron1);
                                intron2.Add(sampledBlyb.intron2);
                                intron3.Add(sampledBlyb.intron3);
                                intron4.Add(sampledBlyb.intron4);

                                moveAllele1.Add(sampledBlyb.moveAllele1);
                                moveAllele2.Add(sampledBlyb.moveAllele2); 

                               redAllele1.Add(sampledBlyb.redAllele1*10f);
                               redAllele2.Add(sampledBlyb.redAllele2*10f);

                               greenAllele1.Add(sampledBlyb.greenAllele1*10f);
                               greenAllele2.Add(sampledBlyb.greenAllele2*10f);

                                blueAllele1.Add(sampledBlyb.blueAllele1*10f);
                                blueAllele2.Add(sampledBlyb.blueAllele2*10f);
                                LifeSpan.Add(sampledBlyb.lifeLength);
                    
                                lookDistance.Add(sampledBlyb.lookDistance);

                                turnTorqueAllele1.Add(sampledBlyb.turnTorqueAllele1);
                                turnTorqueAllele2.Add(sampledBlyb.turnTorqueAllele2);
                                turnDice.Add(sampledBlyb.turnDice);
                                energyToReproduce.Add(sampledBlyb.energyToReproduce);
                                generation.Add(sampledBlyb.generation);
                                conjAge.Add(sampledBlyb.conjAge);
                            }
                        }

                        if (brainCheck == true)
                            for (int i = 0; i < sampleSize; i++)
                            {  
                            sampler = UnityEngine.Random.Range(0,sampleSize);
                            BrainBlybControls sampledBlyb = blybs[sampler].GetComponent<BrainBlybControls>();


                                intron1.Add(sampledBlyb.intron1);
                                intron2.Add(sampledBlyb.intron2);
                                intron3.Add(sampledBlyb.intron3);
                                intron4.Add(sampledBlyb.intron4);

                                moveAllele1.Add(sampledBlyb.moveAllele1);
                                moveAllele2.Add(sampledBlyb.moveAllele2); 

                                redAllele1.Add(sampledBlyb.redAllele1*10f);
                                redAllele2.Add(sampledBlyb.redAllele2*10f);

                                greenAllele1.Add(sampledBlyb.greenAllele1*10f);
                                greenAllele2.Add(sampledBlyb.greenAllele2*10f);

                                blueAllele1.Add(sampledBlyb.blueAllele1*10f);
                                blueAllele2.Add(sampledBlyb.blueAllele2*10f);
                                LifeSpan.Add(sampledBlyb.lifeLength);
                    
                                lookDistance.Add(sampledBlyb.lookDistance);

                                turnTorqueAllele1.Add(sampledBlyb.turnTorqueAllele1);
                                turnTorqueAllele2.Add(sampledBlyb.turnTorqueAllele2);
                                energyToReproduce.Add(sampledBlyb.energyToReproduce);
                                generation.Add(sampledBlyb.generation);
                                conjAge.Add(sampledBlyb.conjAge);

                            }


            }           
                
            
             


            



        
            
                Save();
            
                }

            


            }
        


        void Save(){
            itCount += 1;
            string[] rowDataTemp;
        if (itCount == 1){
            if (refCheck == true)
            {
            rowDataTemp = new string[22];
            rowDataTemp[0] ="time" ;
            rowDataTemp[1] ="species" ;
            rowDataTemp[2] = "sampleGroup";
            rowDataTemp[3] ="generation";
            rowDataTemp[4] = "intron1";
            rowDataTemp[5] = "intron2";
            rowDataTemp[6] = "intron3";
            rowDataTemp[7] = "intron4";
            rowDataTemp[8] = "moveAllele1";
            rowDataTemp[9] = "moveAllele2";
            rowDataTemp[10] = "redAllele1";
            rowDataTemp[11] = "redAllele2";
            rowDataTemp[12] = "greenAllele1";
            rowDataTemp[13] = "greenAllele2";
            rowDataTemp[14] = "blueAllele1";
            rowDataTemp[15] = "blueAllele2";
            rowDataTemp[16] = "maxLifeLength";
            rowDataTemp[17] = "lookDistance";
            rowDataTemp[18] = "turnTorqueAllele1";
            rowDataTemp[19] = "turnTorqueAllele2";
            
            rowDataTemp[20] = "energyToReproduce";
            rowDataTemp[21] = "conjAge";

            rowData.Add(rowDataTemp);
            }

            if (brainCheck == true)

            {
            rowDataTemp = new string[23];
            rowDataTemp[0] ="time" ;
            rowDataTemp[1] ="species" ;
            rowDataTemp[2] = "sampleGroup";
            rowDataTemp[3] ="generation";
            rowDataTemp[4] = "intron1";
            rowDataTemp[5] = "intron2";
            rowDataTemp[6] = "intron3";
            rowDataTemp[7] = "intron4";
            rowDataTemp[8] = "moveAllele1";
            rowDataTemp[9] = "moveAllele2";
            rowDataTemp[10] = "redAllele1";
            rowDataTemp[11] = "redAllele2";
            rowDataTemp[12] = "greenAllele1";
            rowDataTemp[13] = "greenAllele2";
            rowDataTemp[14] = "blueAllele1";
            rowDataTemp[15] = "blueAllele2";
            rowDataTemp[16] = "maxLifeLength";
            rowDataTemp[17] = "lookDistance";
            rowDataTemp[18] = "turnDice";
            rowDataTemp[19] = "turnTorqueAllele1";
            rowDataTemp[20] = "turnTorqueAllele2";      
            rowDataTemp[21] = "energyToReproduce";
            rowDataTemp[22] = "conjAge";

            rowData.Add(rowDataTemp);
            }
        }



        // You can add up the values in as many cells as you want.
        for(int i = 0; i < sampleSize; i++)
        {   if (refCheck == true)

            {
            rowDataTemp = new string[23];
            rowDataTemp[0] = totalTime.ToString();
            rowDataTemp[1] = "blyb";
            rowDataTemp[2] = sampleGroup.ToString();
            rowDataTemp[3] = generation[i].ToString();
            rowDataTemp[4] = intron1[i].ToString();
            rowDataTemp[5] = intron2[i].ToString();
            rowDataTemp[6] = intron3[i].ToString();
            rowDataTemp[7] = intron4[i].ToString();
            rowDataTemp[8] = moveAllele1[i].ToString();
            rowDataTemp[9] = moveAllele2[i].ToString();
            rowDataTemp[10] = redAllele1[i].ToString();
            rowDataTemp[11] = redAllele2[i].ToString();
            rowDataTemp[12] = greenAllele1[i].ToString();
            rowDataTemp[13] = greenAllele2[i].ToString();
            rowDataTemp[14] = blueAllele1[i].ToString();
            rowDataTemp[15] = blueAllele2[i].ToString();
            rowDataTemp[16] = LifeSpan[i].ToString();
            rowDataTemp[17] = lookDistance[i].ToString();
            rowDataTemp[18] = turnTorqueAllele1[i].ToString();
            rowDataTemp[19] = turnTorqueAllele2[i].ToString();
            rowDataTemp[20] = turnDice[i].ToString();
            rowDataTemp[21] = energyToReproduce[i].ToString();
            rowDataTemp[22] = conjAge[i].ToString();
            
            rowData.Add(rowDataTemp);

            }
            if (brainCheck == true)

            {
            rowDataTemp = new string[22];
            rowDataTemp[0] = totalTime.ToString();
            rowDataTemp[1] = "blyb";
            rowDataTemp[2] = sampleGroup.ToString();
            rowDataTemp[3] = generation[i].ToString();
            rowDataTemp[4] = intron1[i].ToString();
            rowDataTemp[5] = intron2[i].ToString();
            rowDataTemp[6] = intron3[i].ToString();
            rowDataTemp[7] = intron4[i].ToString();
            rowDataTemp[8] = moveAllele1[i].ToString();
            rowDataTemp[9] = moveAllele2[i].ToString();
            rowDataTemp[10] = redAllele1[i].ToString();
            rowDataTemp[11] = redAllele2[i].ToString();
            rowDataTemp[12] = greenAllele1[i].ToString();
            rowDataTemp[13] = greenAllele2[i].ToString();
            rowDataTemp[14] = blueAllele1[i].ToString();
            rowDataTemp[15] = blueAllele2[i].ToString();
            rowDataTemp[16] = LifeSpan[i].ToString();
            rowDataTemp[17] = lookDistance[i].ToString();
            rowDataTemp[18] = turnTorqueAllele1[i].ToString();
            rowDataTemp[19] = turnTorqueAllele2[i].ToString();
            rowDataTemp[20] = energyToReproduce[i].ToString();
            rowDataTemp[21] = conjAge[i].ToString();
            
            rowData.Add(rowDataTemp);
            }


        }
    

        string[][] output = new string[rowData.Count][];

        for(int i = 0; i < output.Length; i++){
            output[i] = rowData[i];
        }

        int     length         = output.GetLength(0);
        string     delimiter     = ",";

        StringBuilder sb = new StringBuilder();
        
        for (int index = 0; index < length; index++)
            sb.AppendLine(string.Join(delimiter, output[index]));
        
        
        string filePath = getPath();

        StreamWriter outStream = System.IO.File.CreateText(filePath);
        outStream.WriteLine(sb);
        outStream.Close();
        

        intron1.Clear();
        intron2.Clear();
        intron3.Clear();
        intron4.Clear();

        moveAllele1.Clear();
        moveAllele2.Clear();
        redAllele1.Clear();
        redAllele2.Clear();
        greenAllele1.Clear();
        greenAllele2.Clear();
        blueAllele1.Clear();
        blueAllele2.Clear();
        LifeSpan.Clear();
        lookDistance.Clear();
        turnTorqueAllele1.Clear();
        turnTorqueAllele2.Clear();
        turnDice.Clear();
        energyToReproduce.Clear();
        generation.Clear();
        conjAge.Clear();

        Array.Clear(blybs,0,blybs.Length);
        time = 0f;
        sampleGroup += 1;


    }

    // Following method is used to retrive the relative path as device platform
    private string getPath(){
        #if UNITY_EDITOR
        return Application.dataPath +"/CSV/"+"Blyb_genetics.csv";
        #elif UNITY_ANDROID
        return Application.persistentDataPath+"Blyb_genetics.csv";
        #elif UNITY_STANDALONE_OSX
        return Application.dataPath+"/"+"Blyb_genetics.csv";
        #else
        return Application.dataPath +"/"+"Blyb_genetics.csv";
        #endif
    }
}


