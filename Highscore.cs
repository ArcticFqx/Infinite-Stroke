using UnityEngine;
using System.Collections;
using System.Text;
using System.Security;

public class Highscore : MonoBehaviour 
{
    public string secretKey = "infinitoBandito1234";
	public string PostScoreUrl = "http://henchmangoon.com/infinitestroke/postScore.php?";
	public string GetHighscoreUrl = "http://henchmangoon.com/infinitestroke/getHighscore.php";

	private string name = "Name";
    private string score = "";

    public int achievedScore = 0;

    public UILabel label;
    public UILabel nameLabel;
    public UIButton submitButton;
    public UILabel playerScore;

	private string WindowTitel = "";
	
    private string Score = "";
    private string Level = "";


	public int maxNameLength = 10;
	public int getLimitScore = 15;
	
	
	void Start () 
	{
		StartCoroutine("GetScore");		
	}

	void Update () 
	{
	
	}
	
	public IEnumerator GetScore()
	{
		score = "";
			

		WWWForm form = new WWWForm();
        form.AddField("limit",getLimitScore);
		
    	WWW www = new WWW(GetHighscoreUrl,form);
    	yield return www;
		if(www.text == "") 
    	{
			print("There was an error getting the high score: " + www.error);
    	}
		else 
		{
			
       		label.text = www.text;
		}
	}
	
	IEnumerator PostScore(string name, int thescore)
	{
		string _name = name;
		string _score = thescore.ToString();

		string hash = Md5Sum(_name + _score + secretKey).ToLower();
		
		WWWForm form = new WWWForm();
		form.AddField("name",_name);
		form.AddField("score", score);
        form.AddField("hash",hash);
        
		
		WWW www = new WWW(PostScoreUrl,form);
		WindowTitel = "Wait";
		yield return www;
		
    	if(www.text == "done") 
    	{
       		StartCoroutine("GetScore");
    	}
		else 
		{
			print("There was an error posting the high score: " + www.error);
			WindowTitel = "There was an error posting the high score";
		}
	}
	
	

	
	public string Md5Sum(string input)
	{
    	System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
    	byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
    	byte[] hash = md5.ComputeHash(inputBytes);
 
    	StringBuilder sb = new StringBuilder();
    	for (int i = 0; i < hash.Length; i++)
    	{
    	    sb.Append(hash[i].ToString("X2"));
    	}
    	return sb.ToString();
	}
}
