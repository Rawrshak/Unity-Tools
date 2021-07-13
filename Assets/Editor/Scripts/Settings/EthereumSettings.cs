
using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
using Rawrshak;

public class EthereumSettings : ScriptableObject
{
    public string ethereumGatewayUri;
    public EthereumNetwork networkId;
    public int defaultGasPrice;
    public int chainId;
    public int port;
    public bool askForPasswordAtEveryTransaction;
    public void Init()
    {
        ethereumGatewayUri = "http://localhost";
        networkId = EthereumNetwork.Localhost;
        defaultGasPrice = 20;
        chainId = 5777;
        port = 8545;
        askForPasswordAtEveryTransaction = true;
    }
}