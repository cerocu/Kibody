using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Net;
using System.Xml;
using System.Text.RegularExpressions;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

public class Wikipedia : MonoBehaviour {
	private Text texto1;
	// Use this for initialization
	void Start () {
		//texto = (Text)GameObject.Find ("Texto").GetComponent<Text>();
		//texto.text = (buscarWikipedia("superman"));
		buscarWikipedia("corazon");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string buscarWikipedia(string articulo)
	{
		texto1 = (Text)GameObject.Find ("Texto").GetComponent<Text>();
		ServicePointManager.ServerCertificateValidationCallback = MyRemoteCertificateValidationCallback;
		WebClient wc = new WebClient();
		wc.Encoding = System.Text.Encoding.UTF8;

		string archivo = wc.DownloadString("https://es.wikipedia.org/w/api.php?format=xml&action=query&prop=extracts&titles=" + articulo + "&redirects=true&origin=*");

		XmlDocument xml = new XmlDocument();

		xml.LoadXml(archivo);

		XmlNode nodo = xml.GetElementsByTagName("extract")[0];

		try
		{
			string texto = nodo.InnerText;
		   

			String searchString = "<p>";
			int startIndex = texto.IndexOf(searchString);
			searchString = "</" + searchString.Substring(1);
			int endIndex = texto.IndexOf(searchString);
			texto = texto.Substring(startIndex, endIndex + searchString.Length - startIndex);
		//	Debug.Log("Substring;       "+ texto); 


		


			Regex rx = new Regex("\\<[^\\>]*\\>");
			texto = rx.Replace(texto, "");
		//	Debug.Log("Substring;       "+ texto); 

			Regex rexnum = new Regex("([+[0-9]+])*");

			texto = rexnum.Replace(texto, "");


			Debug.Log(texto);

			return texto;
		}
		catch (Exception ex) { return "El artículo no existe"; }
	}

	public bool MyRemoteCertificateValidationCallback(System.Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) {
		bool isOk = true;
		// If there are errors in the certificate chain, look at each error to determine the cause.
		if (sslPolicyErrors != SslPolicyErrors.None) {
			for(int i=0; i<chain.ChainStatus.Length; i++) {
				if(chain.ChainStatus[i].Status != X509ChainStatusFlags.RevocationStatusUnknown) {
					chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
					chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
					chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 1, 0);
					chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllFlags;
					bool chainIsValid = chain.Build((X509Certificate2)certificate);
					if(!chainIsValid) {
						isOk = false;
					}
				}
			}
		}
		return isOk;
	}
}
