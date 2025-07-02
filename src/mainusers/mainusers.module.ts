import { Module } from '@nestjs/common';
import { MainusersService } from './mainusers.service';
import { MainusersController } from './mainusers.controller';

@Module({
  controllers: [MainusersController],
  providers: [MainusersService],
})
export class MainusersModule {}
