package com.ainhoa.mypokemon

import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import com.ainhoa.mypokemon.databinding.ActivitySecondBinding
import com.google.android.material.tabs.TabLayoutMediator

class SecondActivity : AppCompatActivity() {
    private lateinit var binding: ActivitySecondBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivitySecondBinding.inflate(layoutInflater)
        setContentView(binding.root)

        val viewPager2 = binding.viewPager2

        // Se crea el adapter.
        val adapter = ViewPager2Adapter(supportFragmentManager, lifecycle)

        // Se añaden los fragments y los títulos de pestañas.

        adapter.addFragment(RegistroFragment(), "Datos")
        adapter.addFragment(PokedexFragment(), "Pokedex")


        // Se asocia el adpater al viewPager2
        viewPager2.adapter = adapter

        // Efectos para el viewPager2.
        // viewPager2.setPageTransformer(DepthPageTransformer())
        // Carga de las pestañas en el TabLayout
        TabLayoutMediator(binding.tabLayout, viewPager2){tab, position ->
            tab.text = adapter.getPageTitle(position) }.attach()
    }
}