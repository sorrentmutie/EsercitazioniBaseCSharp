﻿using Padel.Core.Entities;
using Padel.Core.Interfaces;
using Padel.Core.ViewModels;
using System.Net.Http.Json;

namespace DenoPadelBlazorWASM.Services;

public class ServizioIstruttoriBlazorWASM : IDatiIstruttori
{
    public ServizioIstruttoriBlazorWASM(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }


    private static List<IstruttorePadel> istruttoriDisponibili = new List<IstruttorePadel>()
        {
            new IstruttorePadel { Nome = "Mario", Cognome = "Rossi",
             Id = 1, Email = "mario.rossi@gmail.com", NumeroTelefono = "3331234567",
              Qualifica = "Maestro A", DataAssunzioneIstruttore = new DateTime(2021, 1, 1 )
            },
            new IstruttorePadel { Nome = "Luigi", Cognome = "Bianchi",
             Id = 1, Email = "luigi.bianchi@gmail.com", NumeroTelefono = "1133317",
              Qualifica = "Maestro B", DataAssunzioneIstruttore = new DateTime(2020, 1, 1 )
            },
    };

    private static List<IstruttorePadel> istruttoriNeoAssunti = new List<IstruttorePadel>()
    {
        new IstruttorePadel { Nome = "Giuseppe", Cognome = "Verdi",
            Id = 3, Email = "giuseppe.verdi@gmail.com", NumeroTelefono = "3331234567",
            Qualifica = "Maestro C", DataAssunzioneIstruttore = new DateTime(2023, 1, 1 )
        },
    };
    private readonly HttpClient httpClient;

    public void AggiungiIstruttoreDisponibile(IstruttorePadel istruttore)
    {
        var id = 1;
        if(istruttoriDisponibili.Count > 0)
        {
            id = istruttoriDisponibili.Max(i => i.Id) + 1;
        }
        istruttore.Id = id;
        istruttoriDisponibili.Add(istruttore);
    }

    public Task AggiungiIstruttoreDisponibileAsync(IstruttorePadel istruttore)
    {
        throw new NotImplementedException();
    }

    public Task AggiungiLezioneAdIstruttoreAsync(int id, LezioneViewModel lezioneViewModel)
    {
        throw new NotImplementedException();
    }

    public void EliminaIstruttoreDisponibile(IstruttorePadel istruttore)
    {
        istruttoriDisponibili.Remove(istruttore);
    }

    public Task EliminaIstruttoreDisponibileAsync(IstruttorePadel istruttore)
    {
        throw new NotImplementedException();
    }

    public void EliminaIstruttoreNeoAssunto(IstruttorePadel istruttore)
    {
        istruttoriNeoAssunti.Remove(istruttore);
    }

    public Task<DettaglioIstruttoreViewModel> EstraiDettaglioIstruttoreAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IstruttorePadel> EstraiIstruttorePerIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public List<IstruttorePadel> EstraiIstruttoriDisponibili()
    {
        return istruttoriDisponibili;
    }

    public async Task<List<IstruttorePadel>> EstraiIstruttoriDisponibiliAsync()
    {
       var response = await httpClient.GetAsync("https://localhost:7182/istruttori");
       if (response.IsSuccessStatusCode)
       {
            var data = await response.Content.ReadFromJsonAsync<List<IstruttorePadel>>();
            return data ?? new List<IstruttorePadel>();

       } else{
            return new List<IstruttorePadel>();
       }
    }

    public List<IstruttorePadel> EstraiIstruttoriNeoAssunti()
    {
        return istruttoriNeoAssunti;
    }

    public void ModificaIstruttoreDisponibile(IstruttorePadel istruttore)
    {
        var istruttoreDb = istruttoriDisponibili.FirstOrDefault(x => x.Id == istruttore.Id);
        if(istruttoreDb != null)
        {
            istruttoriDisponibili.Remove(istruttoreDb);
            istruttoriDisponibili.Add(istruttore);
        }
    }

    public Task ModificaIstruttoreDisponibileAsync(IstruttorePadel istruttore)
    {
        throw new NotImplementedException();
    }

    public Task PatchIstruttoreDisponibileAsync(IstruttorePadel istruttore)
    {
        throw new NotImplementedException();
    }
}
